* Written by Talha Ya?ar

    ORG     $1000

START:
    * Karsilama mesaji.
    LEA     MSG_WELCOME, A1
    MOVE.B  #14, D0
    TRAP    #15

    * A2'ye gizli kelime tanimlanir.
    LEA     SECRET_WORD, A2
    * A0'i sifirla.
    LEA     FOUND_LETTERS, A0
    MOVE.L  #0, D7            ; Yanlis tahmin sayacini sifirla
    CLR.L   -(A0)             ; FOUND_LETTERS dizisini sifirla
    CLR.L   -(A0)
    CLR.L   -(A0)
    CLR.L   -(A0)
    LEA     FOUND_LETTERS, A0 ; A0'i tekrar baslangica ayarla

    * Main döngüsüne girilir.
    BRA     MAIN_LOOP

MAIN_LOOP:
    ; Kullanicidan harfi oku
    JSR     GET_CHARACTER
    CMP.B   #0, D1             ; Kullanicidan alinan girisin sonunu kontrol et
    BEQ     END_GAME           ; Eger sonu ise oyunu bitir

    MOVE.B  D1, (A0)+          ; Harfi kelimeye ekle

    ; Harfi gizli kelimede ara
    MOVEA.L A2, A3
    MOVE.B  D1, D2
    MOVEQ   #0, D3

FIND_LETTER:
    MOVE.B  (A3)+, D4          ; A3'teki bayti D4'e yükle ve A3'ü arttir
    CMP.B   D4, D2             ; Harfi kontrol et
    BEQ     LETTER_FOUND

    MOVEQ   #0, D5             ; D5'e 0 yükle
    CMP.B   D4, D5             ; Gizli kelimenin sonunu kontrol et
    BEQ     LETTER_NOT_FOUND

    BRA     FIND_LETTER

LETTER_FOUND:
    MOVE.B  #1, D3             ; Harf bulundu bayragini 1 yap
    MOVEA.L A2, A3
    BRA     CHECK_GAME_STATUS

LETTER_NOT_FOUND:
    ADDQ.L  #1, D7             ; Yanlis tahmin sayisini arttir
    CMP.L   #6, D7             ; 6 yanlis tahmin
    BEQ     GAME_OVER

CHECK_GAME_STATUS:
    ; Mevcut durumu göster
    JSR     DISPLAY_WORD_STATUS
    BRA     MAIN_LOOP

GAME_OVER:
    LEA     MSG_GAME_OVER, A1
    MOVE.B  #14, D0
    TRAP    #15
    BRA     END_GAME

END_GAME:
    BRA     END_GAME           ; Sonsuz döngü

; String yazma alt rutini
PRINT_STRING:
    MOVE.B  (A1)+, D1
    BEQ     PRINT_STRING_END
    MOVE.B  D1, D1  ; D1 registerini TRAP #15 ile yazdir
    TRAP    #15
    BRA     PRINT_STRING

PRINT_STRING_END:
    RTS

; Kullanicidan karakter okuma alt rutini
GET_CHARACTER:
    LEA     MSG_ENTER_LETTER, A1
    MOVE.B  #14, D0
    TRAP    #15
    
    MOVE.B  #5, D0
    TRAP    #15
    RTS

; Mevcut durumu gösterme alt rutini
DISPLAY_WORD_STATUS:
    MOVEA.L A2, A3
    LEA     MSG_CURRENT_STATUS, A1
    MOVE.B  #14, D0
    TRAP    #15
    LEA     FOUND_LETTERS, A0

DISPLAY_LOOP:
    MOVE.B  (A3)+, D4
    MOVEQ   #0, D5             ; D5'e 0 yükle
    CMP.B   D4, D5             ; Gizli kelimenin sonunu kontrol et
    BEQ     DISPLAY_END

    MOVEA.L A0, A6
    MOVEQ   #0, D6

FOUND_CHECK:
    CMP.B   (A6)+, D4
    BEQ     PRINT_FOUND
    CMP.B   #0, (A6)
    BEQ     PRINT_UNDERSCORE
    ADDQ.B  #1, D6
    CMP.B   #20, D6
    BGE     PRINT_UNDERSCORE
    BRA     FOUND_CHECK

PRINT_FOUND:
    MOVE.B  D4, D1
    MOVE.B  #14, D0
    TRAP    #15
    BRA     DISPLAY_LOOP

PRINT_UNDERSCORE:
    MOVE.B  #'_', D1
    MOVE.B  #14, D0
    TRAP    #15
    BRA     DISPLAY_LOOP

DISPLAY_END:
    MOVE.B  CR, D1
    MOVE.B  #14, D0
    TRAP    #15
    MOVE.B  LF, D1
    MOVE.B  #14, D0
    TRAP    #15
    RTS

CR      EQU     $0D
LF      EQU     $0A

MSG_WELCOME:         DC.B    'Adam Asmaca Oyununa Hos Geldiniz!',CR,LF,0
MSG_ENTER_LETTER:    DC.B    CR,LF,'Bir Harf Girin: ',0
MSG_CURRENT_STATUS:  DC.B    CR,LF,'Mevcut Durum: ',0
MSG_GAME_OVER:       DC.B    CR,LF,'Oyun Bitti. Yanlis Tahminleriniz 6yi Buldu.',0
SECRET_WORD:         DC.B    'MERHABA',0
FOUND_LETTERS:       DS.B    20
WORD:                DS.B    20

    END     START

*~Font name~Courier New~
*~Font size~14~
*~Tab type~1~
*~Tab size~4~
