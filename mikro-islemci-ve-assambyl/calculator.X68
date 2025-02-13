*-----------------------------------------------------------
* Title      : Vize final hesaplama
* Written by : Talha Ya?ar
* Date       : 05/06/2024
* Description: Girilen vizeler ve final ile not ortalamasi hesaplama programi.
*-----------------------------------------------------------
    ORG    $1000
START:                   
        BRA     Loop
        
*- Islem Dongusu
Loop:
    JSR GetChar ;Girdi alma islemi
    BRA CheckChoice

GetChar:

        * Prompt the user for their choice
        LEA     ChooseFunction,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        * Trap 5 Task - Read the char input from keyboard into D1.B
        MOVE.B  #5,D0
        TRAP    #15
        
        * Move the value from D1 to D4
        MOVE.B  D1,D4
        RTS

CheckChoice:

        * Check if the Char == 'A' for addition
        CMP.B   #$31,D4
        BEQ     AddFunction

        * If not equal ask user to try to input a value again
        ;LEA     InvalidInput,A1
        ;MOVE.B  #14,D0
        ;TRAP    #15
        ;JSR     GetChar
        
        * Stop the Program
        CMP.B   #$30,D4
        BNE     Loop
        BEQ     FINISH
 
 * Halt Simulator
FINISH:

        * Display a message before halting
        LEA     EndProgram,A1
        MOVE.B  #14,D0
        TRAP    #15 
        SIMHALT
        
* Declare the text-prompt variables 
NumberPrompt1:      DC.B    CR,LF,'Enter the first number: ',0
NumberPrompt2:      DC.B    CR,LF,'Enter the second number: ',0
ChooseFunction:     DC.B    CR,LF,'What would you like to do? (A)dd, (S)ubtract, (M)ultiply or (D)ivide? ',0
InvalidInput:       DC.B    CR,LF,'Invalid Choice. Try again ...',0
Result:             DC.B    CR,LF,'Your result: ',0
EndProgram:         DC.B    CR,LF,'Program - Over',0

        END    START        ; last line of source
*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
