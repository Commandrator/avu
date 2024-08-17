    ORG     $1000       ; Program baslangiç adresi

START:
    ;move ile veri tasimasi yapilir, #5 
    MOVE.B  #5, D0      ; D0 register'ina 5 degerini yükle
    MOVE.B  #3, D1      ; D1 register'ina 3 degerini yükle

    ; D0 ve D1 register'larini birbiriyle VE (AND) islemine tabi tut
    AND     D1, D0      ; D0 ve D1 register'larini AND islemine tabi tut, sonucu D0'e yükle

    ; Sonucu saklamak için D2 register'ini kullan
    MOVE    D0, D2      ; D0'deki sonucu D2'ye kopyala

    ; Ekrana sonucu yazdir
    MOVE.B  #14, D0     ; D0 register'ina 14 (PRINT_STRING hizmet çagrisi) yükle
    TRAP    #15         ; Hizmet çagrisini gerçeklestir

    ; Programi sonlandir
    MOVE    #0, D0      ; Programi sonlandirmak için D0 register'ina 0 yükle
    TRAP    #15         ; Hizmet çagrisini gerçeklestir

    END     START       ; Program sonu ve baslangiç adresi

*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
