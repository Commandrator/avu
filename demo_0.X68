*-----------------------------------------------------------
* Title      :
* Written by :
* Date       :
* Description:
*-----------------------------------------------------------
    ORG    $1000
START:                  ; first instruction of program
    CLR.L  D7        ; Clear D0 - alternatively MOVEQ #0,D0
    MOVE.W X,D7      ; Read X

    ; Output initial value...
    LEA    S1,A1
    MOVE.W #255,D1
    MOVE.L D7,D1
    MOVEQ  #17,D0
    TRAP   #15

    LEA    SNUL,A1
    MOVEQ  #13,D0
    TRAP   #15

    MOVE.L D7,D6     ; copy of X
    ASL.L  #2,D6     ; Multiply by 4
    ADD.L  D7,D6     ; 4X plus another X = 5X
    MULU.W D7,D7     ; X^2  
    SUB.L  D6,D7     ; Subtract 5X from X^2
    ADDQ.L #6,D7     ; plus 6

    ; Output answer...
    LEA    S2,A1
    MOVE.L D7,D1
    MOVEQ  #17,D0
    TRAP   #15

    SIMHALT             ; halt simulator

* Put variables and constants here
S1:   DC.B 'Initial :',0
S2:   DC.B 'Answer  :',0
SNUL: DC.B 0
X:     DC.W 1234    ; Initial (fixed) value of X

    END    START        ; last line of source
*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
