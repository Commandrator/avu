    ORG     $1000       ; Program baslangi� adresi

START:  
    MOVE.B  #6,D0      ; D0 register'ina 6 (decimal) degerini y�kle
    NOT.B   D0         ; D0 register'indaki degil islemini uygula
    ; D0 register'indaki sonucu ekrana yazdir
    MOVE.B  D0,D1      ; PRINT_CHAR hizmet �agrisi i�in karakteri D1 register'ina y�kle
    MOVE    #14,D0     ; PRINT_CHAR hizmet �agrisini y�kle
    TRAP    #15        ; TRAP #15 ile karakteri yazdir

    ; Programin sonunu belirtmek i�in RTE (Return from Exception) komutunu kullan
    RTE

    END     START       ; Program sonu ve baslangi� adresi

*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
