; ORG,
; LEA,
; MOVE,
; TRAP,

;SIMHALT,
;DC.B,


        ORG     $1000
START:  LEA     HELLO,A1        ; A1 registerine yazi dizisinin adresini yükle
        MOVE.B  #14,D0          ; D0 registerine 14 (console output) komutunu yükle
        TRAP    #15             ; Yaziyi ekrana yazdir

        SIMHALT                 ; Simülasyonu durdur

HELLO   DC.B    'Hello World',0 ; Yazi dizisi ve sonlandirici null karakter

        END     START           ; Program sonu

*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
