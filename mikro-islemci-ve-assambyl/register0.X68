    ORG     $1000       ; Program baslangi� adresi

START:
    ;move ile veri tasimasi yapilir, #5 
    MOVE.B  #5, D0      ; D0 register'ina 5 degerini y�kle
    MOVE.B  #3, D1      ; D1 register'ina 3 degerini y�kle

    ; D0 ve D1 register'larini birbiriyle VE (AND) islemine tabi tut
    AND     D1, D0      ; D0 ve D1 register'larini AND islemine tabi tut, sonucu D0'e y�kle

    ; Sonucu saklamak i�in D2 register'ini kullan
    MOVE    D0, D2      ; D0'deki sonucu D2'ye kopyala

    ; Ekrana sonucu yazdir
    MOVE.B  #14, D0     ; D0 register'ina 14 (PRINT_STRING hizmet �agrisi) y�kle
    TRAP    #15         ; Hizmet �agrisini ger�eklestir

    ; Programi sonlandir
    MOVE    #0, D0      ; Programi sonlandirmak i�in D0 register'ina 0 y�kle
    TRAP    #15         ; Hizmet �agrisini ger�eklestir

    END     START       ; Program sonu ve baslangi� adresi

*~Font name~Courier New~
*~Font size~10~
*~Tab type~1~
*~Tab size~4~
