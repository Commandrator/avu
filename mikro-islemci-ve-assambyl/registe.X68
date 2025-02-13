    ORG     $1000       ; Program baslangiç adresi

START:  
    MOVE.B  #6,D0      ; D0 register'ina 6 (decimal) degerini yükle
    NOT.B   D0         ; D0 register'indaki degil islemini uygula
    ; D0 register'indaki sonucu ekrana yazdir
    MOVE.B  D0,D1      ; PRINT_CHAR hizmet çagrisi için karakteri D1 register'ina yükle
    MOVE    #14,D0     ; PRINT_CHAR hizmet çagrisini yükle
    TRAP    #15        ; TRAP #15 ile karakteri yazdir

    ; Programin sonunu belirtmek için RTE (Return from Exception) komutunu kullan
    RTE

    END     START       ; Program sonu ve baslangiç adresi

*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
