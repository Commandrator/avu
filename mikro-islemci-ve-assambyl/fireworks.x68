*************************************************************************************
*														*
*	Fireworks for EASy68k V1.01					2011/06/04			*
*														*
*	Fireworks launch, fly, explode and fall with reasonably realistic physics.	*
*														*
*	The first version used 16 bit integer maths but this resulted in rounding	*
*	artifacts being visible as symetric spacing of supposedly random particles	*
*	and waves of velocity change as an effect rounded to the next bit.		*
*														*
*	This program uses 16.16 fixed point math to reduce rounding artifacts to	*
*	near invisibility.										*
*														*
*														*
*	The [F2], [F3] and [F4]	keys can be used to select a screen size of 640 x	*
*	480, 800 x 600 and 1024 x 768 respectively.						*
*														*
*	[ESC] can be used to quit the program.							*
*														*
*	More 68000 and other projects can be found on my website at ..			*
*														*
*	 http://mycorner.no-ip.org/index.html							*
*														*
*	mail : leeedavison@googlemail.com								*
*														*
*************************************************************************************
*
* first some constants

ESC		EQU	$1B				* [ESC] character
CR		EQU	$0D				* [CR] character
LF		EQU	$0A				* [LF] character

num_objs	EQU	200				* number of objects

gravity	EQU $00010000			* acceleration due to gravity

rocket	EQU	  2				* rocket object
zorst		EQU	  4				* exhaust object
burst		EQU	  6				* burst object
star		EQU	  8				* star object

rocket_drag	EQU	 10				* rocket v^2 drag effect
zorst_drag	EQU	 64				* exhaust v^2 drag effect
burst_drag	EQU	128				* burst v^2 drag effect
star_drag	EQU	200				* star v^2 drag effect

rocket_life	EQU	 40				* rocket life
zorst_life	EQU	 -1				* exhaust life
burst_life	EQU	  2				* burst life minimum
star_life	EQU	  1				* star life

burst_v	EQU	 17				* burst particle velocity minimum


*************************************************************************************
*
* the code

	ORG	$1000

start
	BSR		Initialise			* go setup everything
restart
	BSR		setup_world			* go setup the firework world
main_loop
	MOVEQ		#8,d0				* get the time in 1/100 ths seconds
	TRAP		#15

	MOVE.l	d1,-(sp)			* save the time

	MOVEQ		#94,d0			* copy the screen buffer to the screen
	TRAP		#15

	MOVEQ		#11,d0			* position cursor
	MOVE.w	#$FF00,d1			* clear screen
	TRAP		#15

* animate the scene

	BSR		new_rocket			* go see if a new rocket is needed
	BSR.s		update_objects		* go update the objects
	BSR		draw_objects		* draw the objects

* test the keys used

	BSR		screen_size			* test and handle widow size change keys
	BSR		test_escape			* test if the user wants to quit

* now see if we need to wait for some time

	MOVE.l	(sp)+,d7			* get the main loop start time
	MOVEQ		#8,d0				* get time in 1/100 ths seconds
	TRAP		#15

* doing the BGT means that if the clock passed midnight while the code was in the main
* loop then the delay is skipped this go. this means things may run a bit fast for one
* loop which is waaaaay better than waiting for a few 100ths of a second shy of twenty
* four hours by mistake

	SUB.l		d1,d7				* subtract the current time from the start time
	BGT.s		end_main_loop		* if the time crossed midnight just contimue

* moving the wait time into d1 like this menas we can have any wait up to 1.27 seconds
* and still use the MOVEQ form to load it

	MOVEQ		#5,d1				* set the wait time in 100ths of a second
	ADD.l		d7,d1				* add the loop negative time delta
	BLE.s		end_main_loop		* if the time is up just contimue

	MOVEQ		#23,d0			* else wait d1 100ths of a second
	TRAP		#15

end_main_loop
	TST.w		redraw(a3)			* test the redraw flag
	BNE.s		restart			* if redraw go initialise the world

	TST.w		quit(a3)			* test the quit flag
	BEQ.s		main_loop			* if not quit go get another key

* all done so tidy up and stop

	MOVEQ		#16,d1			* disable double buffering
	MOVEQ		#92,d0			* set draw mode
	TRAP		#15

	LEA		goodbye_message(pc),a1	* set the goodbye message pointer
	MOVEQ		#13,d0			* display a string with [CR][LF]
	TRAP		#15

	MOVEQ		#9,d0				* halt the simulator
	TRAP		#15

goodbye_message
	dc.b	$0C,CR,LF
	dc.b	'  Goodbye',0

	ds.w	0					* ensure even


*************************************************************************************
*
* update the objects routine

update_objects
	MOVE.w	#obj_length*num_objs-obj_length,d7
							* set the index to the last object
update_loop
	MOVE.w	obj_type(a0,d7.w),d0	* get the object type
	BEQ		end_update_loop		* if no object go do next

	CMPI.w	#rocket,d0			* compare the object type with a rocket
	BNE.s		not_a_rocket		* if not a rocket skip exhast spawn

	BSR		spawn_zorst			* go spawn an exhast particle
not_a_rocket
	MOVE.l	obj_x(a0,d7.w),d1		* get the object x co-ordinate
	MOVE.l	obj_y(a0,d7.w),d2		* get the object y co-ordinate

	MOVE.l	obj_vx(a0,d7.w),d3	* get the object x velocity
	MOVE.l	obj_vy(a0,d7.w),d4	* get the object y velocity

	ADD.l		d3,d1				* add the x velocity to the x co-ordinate
	BMI.s		object_done			* if < 0 then the object is off screen

	ADD.l		d4,d2				* add the y velocity to the y co-ordinate
*##	BMI.s		object_done			* if < 0 then the object is off screen. I took
							* this out to allow particles that go off the
							* top of the screen to re-enter when they fall
							* back as long as they stay within the x bounds

	SWAP		d1				* high word to low word
	CMP.w		width(a3),d1		* compare x with the screen width
	BGE.s		object_done			* if >= max + 1 then the object is off screen

	SWAP		d2				* high word to low word
	CMP.w		height(a3),d2		* compare y with the screen height
	BGE.s		object_done			* if >= max + 1 then the object is off screen

	SWAP		d1				* low word back to high word
	SWAP		d2				* low word back to high word

	MOVE.l	d1,obj_x(a0,d7.w)		* save the object x co-ordinate
	MOVE.l	d2,obj_y(a0,d7.w)		* save the object y co-ordinate

	BSR		calc_drag			* calculate (v^2)*drag
	ADD.l		d3,obj_vx(a0,d7.w)	* add the drag to the object x velocity

	MOVE.l	d4,d3				* copy vy
	BSR		calc_drag			* calculate (v^2)*drag
	ADD.l		d3,obj_vy(a0,d7.w)	* add the drag to the object y velocity

	TST.w		obj_accel(a0,d7.w)	* test the acceleration flag
	BEQ.s		no_acceleration		* if done skip acceleration

	SUBQ.w	#1,obj_accel(a0,d7.w)	* decrement the acceleration flag

	MOVE.l	obj_x_accel(a0,d7.w),d1	* get the x acceleration
	MOVE.l	obj_y_accel(a0,d7.w),d2	* get the y acceleration
	ADD.l		d1,obj_vx(a0,d7.w)	* add x acceleration to the x velocity
	ADD.l		d2,obj_vy(a0,d7.w)	* add y acceleration to the y velocity
no_acceleration
	ADD.l		#gravity,obj_vy(a0,d7.w)
							* add gravity to the y velocity
	SUBQ.w	#1,obj_life(a0,d7.w)	* decrement the object life
	BNE.s		end_update_loop		* if still alive skip killing the object

	BSR.s		spawn_object		* the object has timed out so see if it spawns
object_done
	MOVEQ		#0,d0				* clear the longword
	MOVE.w	d0,obj_life(a0,d7.w)	* clear the object life flag
	MOVE.w	d0,obj_type(a0,d7.w)	* clear the object type flag
	SUBQ.w	#1,obj_count(a3)		* decrement the objects count
end_update_loop
	SUB.w		#obj_length,d7		* decrement to previous object
	BPL		update_loop			* loop if not all done

exit_update_objects
	RTS


*************************************************************************************
*
* an object has died so see if it spawns anything

spawn_object
	MOVE.w	obj_type(a0,d7.w),d0	* get the object type
	CMPI.w	#rocket,d0			* compare the object type with a rocket
	BEQ.s		spawn_burst			* if it is a rocket go spawn a burst

	CMPI.w	#burst,d0			* compare the object type with a burst
	BEQ.s		spawn_star			* if it is a burst go spawn a star

	RTS


*************************************************************************************
*
* spawn a star. when a burst dies it spawns a star which is a brief flash of white
* at the end

spawn_star
	MOVE.w	#obj_length*num_objs-obj_length,d6
							* set the index to the last object
spawn_star_loop
	CMP.w		d6,d7				* compare with this object
	BEQ.s		end_spawn_star_loop	* if this object go try next

	TST.w		obj_type(a0,d6.w)		* test the object type flag
	BEQ.s		spawn_a_star		* if this object is free use it

end_spawn_star_loop
	SUB.w		#obj_length,d6		* decrement to previous object
	BPL.s		spawn_star_loop		* loop if not all done

	RTS

* found a vacant object, copy the burst parameters

spawn_a_star
	BSR		copy_object			* copy the burst object to the star object
							* returns this object pointer, (a0,d6.w), in a2

	MOVE.w	#star_drag,obj_drag(a2)	* set the drag

* star_colour(a3) could be used to have other colour stars apart from white

	MOVE.l	star_colour(a3),obj_colour(a2)
							* set the object colour
* set the object type

	MOVEQ		#star,d0			* set the object type
	MOVE.w	d0,obj_type(a2)		* save the object type

* set the object life

	MOVEQ		#star_life,d0		* set the object life
	MOVE.w	d0,obj_life(a2)		* save the object life

* add the object to the count

	ADDQ.w	#1,obj_count(a3)		* increment the objects count

	RTS


*************************************************************************************
*
* spawn a burst. this fills all the free object slots with burst objects

spawn_burst
	MOVEQ		#8,d2				* velocity change is 0 to 7
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	ADD.w		#burst_v,d0			* velocity from burst_v
	MOVE.w	d0,v_burst(a3)		* copy the velocity max for this burst

	MOVE.w	#obj_length*num_objs-obj_length,d6
							* set the index to the last object
spawn_burst_loop
	CMP.w		d6,d7				* compare with this object
	BEQ.s		end_spawn_burst_loop	* if this object go try next

	TST.w		obj_type(a0,d6.w)		* test the object type
	BNE.s		end_spawn_burst_loop	* if object go try next

* found a vacant object, copy the burst parameters

	BSR		copy_object			* copy the burst object to the star object
							* returns this object pointer, (a0,d6.w), in a2

	MOVE.w	#burst_drag,obj_drag(a2)
							* set the drag
* chose a random velocity

	MOVE.w	v_burst(a3),d2		* get the velocity maximum for this burst
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	MOVE.w	d0,d3				* copy the random velocity

* chose a random direction

	BSR		random_n			* get the next random number
	MOVE.w	PRNlword(a3),d0		* get the random direction word
	BSR		sincos			* get sin(d0) in d0, cos(d0) in d1

	MULS.w	d3,d0				* velocity * sin direction
	MULS.w	d3,d1				* velocity * cos direction

* add the velocity to the inherited velocity

	ADD.l		d1,obj_vx(a2)		* add the x velocity to the burst x velocity
	ADD.l		d0,obj_vy(a2)		* add the y velocity to the burst y velocity

* chose a colour

	MOVE.l	burst_colour(a3),d0	* get the object colour
	BPL.s		save_burst_colour		* if it is a valid colour go save it

							* else this is a multicolour burst so
	BSR		get_colour			* get a random colour from the table
save_burst_colour
	MOVE.l	d0,obj_colour(a2)		* save the object colour

* set the object type

	MOVEQ		#burst,d0			* set the object type
	MOVE.w	d0,obj_type(a2)		* save the object type

* set a random life depending on the screen size

	MOVE.w	width(a3),d2		* get the width
	ASR.w		#4,d2				* / 16
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	ADDQ.w	#burst_life,d0		* add the object life
	MOVE.w	d0,obj_life(a2)		* save the object life

* add the object to the count

	ADDQ.w	#1,obj_count(a3)		* increment the objects count
end_spawn_burst_loop
	SUB.w		#obj_length,d6		* decrement to previous object
	BPL.s		spawn_burst_loop		* loop if not all done

	RTS


*************************************************************************************
*
* spawn an exhast particle

spawn_zorst
	TST.w		obj_accel(a0,d7.w)	* test the acceleration flag
	BEQ.s		exit_spawn_zorst		* if done skip spawn

	MOVE.w	#obj_length*num_objs-obj_length,d6
							* set the index to the last object
spawn_zorst_loop
	TST.w		obj_type(a0,d6.w)		* test the object type
	BNE.s		end_spawn_zorst_loop	* if object go try next

* found a vacant object, copy the rocket parameters

	BSR		copy_object			* copy the rocket object to the burst object
							* returns this object pointer, (a0,d6.w), in a2

	MOVE.w	#zorst_drag,obj_drag(a2)
							* set the drag

* kill any acceleration, only need to clear the flag

	MOVEQ		#0,d0				* clear the longword
	MOVE.w	d0,obj_accel(a2)		* clear the acceleration flag

* make the velocity half that of the rocket, this is glowing exhaust that is ejected
* from the rocket so it will be traveling in the same direction as the rocket but
* behind it and slower

	MOVE.l	obj_vx(a2),d1		* get the zorst x velocity
	MOVE.l	obj_vy(a2),d2		* get the zorst y velocity
	ASR.l		#1,d1				* x velocity / 2
	ASR.l		#1,d2				* y velocity / 2
	MOVE.l	d1,obj_vx(a2)		* save the zorst x velocity
	MOVE.l	d2,obj_vy(a2)		* save the zorst y velocity

	MOVE.l	zorst_colour(a3),obj_colour(a2)
							* set the object colour
* set the object type

	MOVEQ		#zorst,d0			* set the object type
	MOVE.w	d0,obj_type(a2)		* save the object type

* set the object life

	MOVEQ		#zorst_life,d0		* set the object life
	MOVE.w	d0,obj_life(a2)		* save the object life

* add the object to the count

	ADDQ.w	#1,obj_count(a3)		* increment the objects count
	RTS

end_spawn_zorst_loop
	SUB.w		#obj_length,d6		* decrement to previous object
	BPL.s		spawn_zorst_loop		* loop if not all done

exit_spawn_zorst
	RTS


*************************************************************************************
*
* new rocket routine. sets up a new rocket object as object zero

new_rocket
	TST.w		obj_count(a3)		* test the objects count
	BNE		exit_new_rocket		* if objects exist just exit

* no objects so a new rocket is needed

	MOVE.w	width(a3),d2		* get the width of the window
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	SWAP		d0				* low word to high word
	MOVE.l	d0,obj_x(a0)		* set the object x co-ordinate

* start from near the bottom of the screen, actually 4 pixels up from the bottom

	MOVEQ		#0,d2				* clear the longword
	MOVE.w	height(a3),d2		* get the height of the window
	SUBQ.w	#4,d2				* - 4
	SWAP		d2				* low word to high word
	MOVE.l	d2,obj_y(a0)		* set the object y co-ordinate

* the rocket starts stationary and accelerates up so clear the initial velocity

	MOVE.l	#0,obj_vx(a0)		* set the object x velocity
	MOVE.l	#0,obj_vy(a0)		* set the object y velocity

	MOVE.w	#rocket_drag,obj_drag(a0)
							* set the drag
* set the acceleration time

	MOVE.w	#22,obj_accel(a0)		* set the object acceleration count

* set a random x acceleration depending on the object's initial x position

	SWAP		d0				* swap the x position back to low word
	MOVE.l	d0,d1				* copy it
	MOVE.w	width(a3),d2		* set the range
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	SUB.l		d1,d0				* - x
	ASL.l		#6,d0				* * 64
	MOVE.l	d0,obj_x_accel(a0)	* set the object x acceleration

* set a random y acceleration depending on the screen height. a1 is used because putting
* a value in an address register doesn't alter the flags from the compare

	MOVE.w	height(a3),d2		* get the screen height
	MOVEA.l	#$FFFDD000,a1		* set for 800 x 600
	CMPI.w	#600,d2			* compare the height with 600
	BEQ.s		set_accel			* if 800 x 600 go use the value

	MOVEA.l	#$FFFD9000,a1		* set for 1024 x 768
	BPL.s		set_accel			* if 1024 x 768 go use the value

	MOVEA.l	#$FFFE0000,a1		* else set for 640 x 480

set_accel
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	ASL.l		#6,d0				* * 64
	ADD.l		d0,a1				* adjust the object y acceleration
	MOVE.l	a1,obj_y_accel(a0)	* save the object y acceleration

	MOVE.l	rocket_colour(a3),obj_colour(a0)
							* set the object colour
* set the object type

	MOVEQ		#rocket,d0			* set the object type
	MOVE.w	d0,obj_type(a0)		* save the object type

* set the object life

	MOVEQ		#rocket_life,d0		* set the object life
	MOVE.w	d0,obj_life(a0)		* save the object life

* add the object to the count

	ADDQ.w	#1,obj_count(a3)		* increment the objects count

* each rocket has a different coloured burst so set the burst colour

	BSR.s		get_col_f			* get a random colour or flag from the table
	MOVE.l	d0,burst_colour(a3)	* save the burst colour

exit_new_rocket
	RTS


*************************************************************************************
*
* get a random colour or flag from the table

get_col_f
	MOVEQ		#colour_fla/4,d2		* set for the table length with the flag
	BRA.s		get_colour_less		* go get the colour


*************************************************************************************
*
* get a random colour from the table

get_colour
	MOVEQ		#colour_len/4,d2		* set for the table length
get_colour_less
	BSR		rand_d2			* generate a random value in d0.w in range
							* 0 to d2.w - 1
	ASL.w		#2,d0				* * 4
	MOVE.l	colours(pc,d0.w),d0	* get a random colour
	RTS

* colours for the bursts

colours
	dc.l	$0000C0				* dark red
	dc.l	$0000FF				* red
	dc.l	$00C000				* dark green
	dc.l	$00FF00				* green
	dc.l	$00FFC0				* mustard
	dc.l	$00C0FF				* orange
	dc.l	$00FFFF				* yellow
	dc.l	$C00000				* dark blue
	dc.l	$FF0000				* blue
	dc.l	$C000C0				* dark magenta
	dc.l	$FF00FF				* magenta
	dc.l	$C0C000				* dark cyan
	dc.l	$FFFF00				* cyan
	dc.l	$C0C0C0				* light
colour_len	EQU	*-colours			* table length
	dc.l	-1					* flag random colour
colour_fla	EQU	*-colours			* table length with the flag


*************************************************************************************
*
* copy an object from index d7 to index d6. this returns (a0,d6.w) in a2 which makes
* some following code much simpler

copy_object
	LEA		(a0,d7.w),a1		* copy the source address
	LEA		(a0,d6.w),a2		* copy the destination address
	MOVEQ		#obj_length-2,d0		* set the word count
copy_object_loop
	MOVE.w	(a1,d0.w),(a2,d0.w)	* copy a word
	SUBQ.w	#2,d0				* decrement the index
	BPL.s		copy_object_loop		* loop if more to do

	RTS


*************************************************************************************
*
* calculate v^2 * drag. all done in 16.16 bit fixed point math

calc_drag
	MOVE.l	d3,d1				* copy the velocity
	BPL.s		positive			* if positive skip negate

	NEG.l		d3				* else make positive
positive

* first do v^2

*					 aaaa bbbb
*					*		= b * b + 2(a * b) + a * a
*					 aaaa bbbb
*
*					 BBBB BBBB
*				  ABAB ABAB
*				  ABAB ABAB
*			   AAAA AAAA

	MOVE.w	d3,d2				* copy low word
	SWAP		d3				* high word to low word
	MOVE.w	d3,d0				* copy high word

	MULU.w	d2,d0				* make AB
	ADD.l		d0,d0				* make AB + AB

	MULU.w	d2,d2				* make BB
	MULU.w	d3,d3				* make AA

	ADD.l		#$00008000,d2		* round up the high word in BBBB BBBB
	CLR.w		d2				* clear the low word
	SWAP		d2				* high word to low word
	ADD.l		d2,d0				* add to Ab

	SWAP		d3				* low word to high word
	CLR.w		d3				* clear the low word
	ADD.l		d0,d3				* add to AA

* now multiply by the drag

*					 aaaa bbbb
*					*		= b * c + a * c
*					 0000 cccc
*
*					 CBCB CBCB
*				  CACA CACA

	MOVE.w	d3,d2				* copy the low word
	SWAP		d3				* high word to low word

	MOVE.w	obj_drag(a0,d7.w),d1	* get the object drag
	MULU.w	d1,d2				* make CB
	MULU.w	d1,d3				* make CA

	ADD.l		#$00008000,d2		* round up
	CLR.w		d2				* clear low word
	SWAP		d2				* high word to low word
	ADD.l		d2,d3				* add to CA

	TST.l		d1				* test the original sign
	BMI.s		negative			* if the original was negative skip the ^2 sign
							* change

	NEG.l		d3				* else make v^2 * drag negative
negative
	RTS


*************************************************************************************
*
* object draw routine. draws all the existing objects

draw_objects
	MOVE.w	#obj_length*num_objs-obj_length,d7
							* set the index to the last object
draw_loop
	MOVE.w	obj_type(a0,d7.w),d5	* get the object type flag
	BEQ.s		end_draw_loop		* if no object go do next

* this object exists so set the pen colour

	MOVE.l	obj_colour(a0,d7.w),d1	* get the object colour
	MOVEQ		#80,d0			* set pen colour
	TRAP		#15

* get the object's position

	MOVE.w	obj_y(a0,d7.w),d2		* get the object y co-ordinate
	BMI.s		end_draw_loop		* if off screen go do the next object

	MOVE.w	obj_x(a0,d7.w),d1		* get the object x co-ordinate

* make x2,y2 for a 2 x 2 object on screen

	MOVE.w	d1,d3				* copy x1
	ADDQ.w	#1,d3				* x2 = x1 + 1
	MOVE.w	d2,d4				* copy y1
	ADDQ.w	#1,d4				* y2 = y1 + 1

* stars are different, see if this is a star

	SUBQ.w	#star,d5			* is the object a star
	BNE.s		not_star			* if not go draw a general object

* the object is a star so make it 3 x 3

	SUBQ.w	#1,d1				* x1 = x1 - 1
	SUBQ.w	#1,d2				* y1 = y1 - 1
not_star
	MOVEQ		#87,d0			* draw a filled rectangle
	TRAP		#15

end_draw_loop
	SUB.w		#obj_length,d7		* decrement to previous object
	BPL.s		draw_loop			* loop if not all done

	RTS


*************************************************************************************
*
* object world setup routine. clear the life and type for each object, get the screen
* size and set the colours

setup_world
	LEA		objects(a3),a0		* a0 points to the fire objects

	MOVEQ		#0,d0				* clear the longword
	MOVE.w	#obj_length*num_objs-obj_length,d7
							* set the index to the last object
clear_loop
	MOVE.w	d0,obj_life(a0,d7.w)	* clear the object life flag
	MOVE.w	d0,obj_type(a0,d7.w)	* clear the object type flag
	SUB.w		#obj_length,d7		* decrement the index to the previous object
	BPL.s		clear_loop			* loop if not all done

	MOVE.w	d0,obj_count(a3)		* clear the objects count
	MOVE.w	d0,redraw(a3)		* clear the redraw flag

* get the screen size

	MOVEQ		#0,d1				* get current window size
	MOVEQ		#33,d0			* set/get output window size
	TRAP		#15

	MOVE.l	d1,width(a3)		* save the screen x,y size

* set the colours

	MOVE.l	#$0000FF,d1			* set the rocket colour
	MOVE.l	d1,rocket_colour(a3)	* save the rocket colour

	MOVE.l	#$00FFFF,d1			* set the exhaust colour
	MOVE.l	d1,zorst_colour(a3)	* save the exhaust colour

	MOVE.l	#$FFFFFF,d1			* set the star colour
	MOVE.l	d1,star_colour(a3)	* save the star colour

	MOVEQ		#81,d0			* set the fill colour
	TRAP		#15

	RTS


*************************************************************************************
*
* setup stuff

Initialise
	MOVEQ		#17,d1			* enable double buffering
	MOVEQ		#92,d0			* set draw mode
	TRAP		#15

	LEA		variables(pc),a3		* get the variables base address

	MOVEQ		#8,d0				* get time in 1/100 ths seconds
	TRAP		#15

	EORI.l	#$DEADBEEF,d1		* EOR with the initial PRNG seed, this must
							* result in any value but zero
	MOVE.l	d1,PRNlword(a3)		* save the initial PRNG seed

	MOVEQ		#0,d1				* clear the longword
	MOVE.w	d1,quit(a3)			* clear the quit flag

	RTS


*************************************************************************************
*
* test if the user wants to quit

test_escape
	MOVEQ		#7,d0				* read the key status
	TRAP		#15

	TST.b		d1				* test the result
	BEQ.s		exit_test_escape		* if no key just exit

	MOVEQ		#5,d0				* read a key
	TRAP		#15

	CMPI.b	#ESC,d1			* compare with [ESC]
	BNE.s		exit_test_escape		* if not [ESC] just exit

	MOVEQ		#-1,d1			* set the longword
	MOVE.w	d1,quit(a3)			* set the quit flag
exit_test_escape
	RTS


*************************************************************************************
*
* check the [F2], [F3] and [F4] keys. set the screen size to 640 x 480, 800 x 600 or
* 1024 x 768 if the corresponding key has been pressed

screen_size
	MOVE.l	#$71007273,d1		* [F2], [], [F3] and [F4] keys
	MOVEQ		#19,d0			* check for keypress
	TRAP		#15

	MOVE.l	d1,d2				* copy result
	BEQ.s		notscreen			* skip screen size if no F key

	MOVE.l	#$028001E0,d1		* set 640 x 480
	TST.l		d2				* test result
	BMI.s		setscreen			* if F2 go set window size

	MOVE.l	#$03200258,d1		* set 800 x 600
	TST.w		d2				* test result
	BMI.s		setscreen			* if F3 go set window size

							* else was F4 so ..
	MOVE.l	#$04000300,d1		* set 1024 x 768
setscreen
	CMP.l		width(a3),d1		* compare with current screen size
	BEQ.s		notscreen			* if already set skip setting it now

	MOVEQ		#33,d0			* get/set window size
	TRAP		#15

	MOVEQ		#-1,d0			* set the longword
	MOVE.w	d0,redraw(a3)		* set the redraw flag
notscreen
	RTS


*************************************************************************************
*
* generate a random value in d0.w in range 0 to d2.w - 1

rand_d2
	BSR.s		random_n			* generate a random number
	MOVEQ		#0,d0				* clear longword
	MOVE.w	PRNlword(a3),d0		* get a random word
	DIVU.w	d2,d0				* divide by range
	CLR.w		d0				* clear the low word
	SWAP		d0				* use the remainder
	RTS


*************************************************************************************
*
* This is the code that generates the pseudo random sequence. A seed word located in
* PRNlword(a3) is loaded into a register before being operated on to generate the
* next number in the sequence. This number is then saved as the seed for the next
* time it's called.
*
* This code is adapted from the 32 bit version of RND(n) used in EhBASIC68. Taking
* the 19th next number is slower but helps to hide the shift and add nature of this
* generator as can be seen from analysing the output.

random_n
	MOVEM.l	d0-d2,-(sp)			* save d0, d1 and d2
	MOVE.l	PRNlword(a3),d0		* get current seed longword
	MOVEQ		#$AF-$100,d1		* set EOR value
	MOVEQ		#18,d2			* do this 19 times
Ninc0
	ADD.l		d0,d0				* shift left 1 bit
	BCC.s		Ninc1				* if bit not set skip feedback

	EOR.b		d1,d0				* do Galois LFSR feedback
Ninc1
	DBF		d2,Ninc0			* loop

	MOVE.l	d0,PRNlword(a3)		* save back to seed longword
	MOVEM.l	(sp)+,d0-d2			* restore d0, d1 and d2

	RTS


*************************************************************************************
*
* get sin(d0) in d0, cos(d0) in d1

sincos
	MOVE.w	d0,d1				* copy the angle
	BSR.s		cos_d0			* get COS(d0) in d0
	EXG		d0,d1				* swap it with d1

	BRA.s		sin_d0			* get SIN(d0) in d0 and return


*************************************************************************************
*
* get COS(d0) in d0. d0 is a nine bit value representing a full circle with the value
* increasing as you turn widdershins

cos_d0
	ADD.w		#$80,d0			* add 1/4 rotation

*************************************************************************************
*
* get SIN(d0) in d0. d0 is a nine bit value representing a full circle with the value
* increasing as you turn widdershins

sin_d0
	BTST		#8,d0				* test angle sign
	BEQ.s		cossin_d0			* just get SIN/COS and return if +ve

	BSR.s		cossin_d0			* else get SIN/COS
	NEG.w		d0				* now do twos complement
	RTS

* get d0.w from SIN/COS table

cossin_d0
	TST.b		d0				* test for >= $80
	BPL.s		a_was_less			* branch if < 1/4 circle

	NEG.b		d0				* wrap $81 to $FF to $7F to $01
a_was_less
	AND.w		#$FF,d0			* ensure word high byte clear
	ADD.w		d0,d0				* * 2 bytes per word value
	MOVE.w	sin_cos(pc,d0.w),d0	* get the SIN/COS value from the table
	RTS


*************************************************************************************
*
* SIN/COS table, returns values between $0000 and $7FFF. the last value should be
* $8000 but that can cause an overflow in the word length calculations and it's
* easier to fudge the table a bit. no one will ever notice.

sin_cos
	dc.w	$0000,$0192,$0324,$04B6,$0648,$07D9,$096B,$0AFB
	dc.w	$0C8C,$0E1C,$0FAB,$113A,$12C8,$1455,$15E2,$176E
	dc.w	$18F9,$1A83,$1C0C,$1D93,$1F1A,$209F,$2224,$23A7
	dc.w	$2528,$26A8,$2827,$29A4,$2B1F,$2C99,$2E11,$2F87
	dc.w	$30FC,$326E,$33DF,$354E,$36BA,$3825,$398D,$3AF3
	dc.w	$3C57,$3DB8,$3F17,$4074,$41CE,$4326,$447B,$45CD
	dc.w	$471D,$486A,$49B4,$4AFB,$4C40,$4D81,$4EC0,$4FFB
	dc.w	$5134,$5269,$539B,$54CA,$55F6,$571E,$5843,$5964
	dc.w	$5A82,$5B9D,$5CB4,$5DC8,$5ED7,$5FE4,$60EC,$61F1
	dc.w	$62F2,$63EF,$64E9,$65DE,$66CF,$67BD,$68A7,$698C
	dc.w	$6A6E,$6B4B,$6C24,$6CF9,$6DCA,$6E97,$6F5F,$7023
	dc.w	$70E3,$719E,$7255,$7308,$73B6,$7460,$7505,$75A6
	dc.w	$7642,$76D9,$776C,$77FB,$7885,$790A,$798A,$7A06
	dc.w	$7A7D,$7AEF,$7B5D,$7BC6,$7C2A,$7C89,$7CE4,$7D3A
	dc.w	$7D8A,$7DD6,$7E1E,$7E60,$7E9D,$7ED6,$7F0A,$7F38
	dc.w	$7F62,$7F87,$7FA7,$7FC2,$7FD9,$7FEA,$7FF6,$7FFE
	dc.w	$7FFF


*************************************************************************************
*
* variables used

variables

	OFFSET	0				* going to use relative addressing

PRNlword
	ds.l	1					* PRNG seed long word
quit
	ds.w	1					* quit flag
redraw
	ds.w	1					* redraw the world flag

width
	ds.w	1					* screen width
height
	ds.w	1					* screen height

rocket_colour
	ds.l	1					* rocket colour
zorst_colour
	ds.l	1					* exhaust colour
burst_colour
	ds.l	1					* burst colour
star_colour
	ds.l	1					* star colour

v_burst
	ds.w	1					* burst velocity for this burst
obj_count
	ds.w	1					* the number ot active objects

objects
obj_life					EQU	*-objects
	ds.w	1					* object life
obj_type					EQU	*-obj_life
	ds.w	1					* object type
obj_x						EQU	*-obj_life
	ds.l	1					* object x co-ordinate	16.16
obj_y						EQU	*-obj_life
	ds.l	1					* object y co-ordinate	16.16
obj_vx					EQU	*-obj_life
	ds.l	1					* object x velocity	16.16
obj_vy					EQU	*-obj_life
	ds.l	1					* object y velocity	16.16
obj_drag					EQU	*-obj_life
	ds.w	1					* drag effect
obj_accel					EQU	*-obj_life
	ds.w	1					* acceleration life
obj_x_accel					EQU	*-obj_life
	ds.l	1					* object x acceleration	16.16
obj_y_accel					EQU	*-obj_life
	ds.l	1					* object y acceleration	16.16
obj_colour					EQU	*-obj_life
	ds.l	1					* object colour
obj_length					EQU	*-obj_life

	ds.b	obj_length*num_objs-obj_length
							* room for the rest of the objects

*************************************************************************************


	END	start


*************************************************************************************
