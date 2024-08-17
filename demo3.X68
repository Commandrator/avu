; Adam Asmaca Oyunu (Düzeltilmis)

	RG $1000

; Mesajlar
MSG_WELCOME: .data "Adam Asmaca Oyununa Hos Geldiniz!\n\0"
MSG_ENTER_LETTER: .data "\nBir Harf Girin: \0"
MSG_CURRENT_STATUS: .data "\nMevcut Durum: \0"
MSG_GAME_OVER: .data "\nOyun Bitti. Yanlis Tahminleriniz 6yi Buldu.\n\0"
MSG_YOU_WIN: .data "\nTebrikler! Kelimeyi Buldunuz!\n\0"

; Gizli Kelime (Degistirilebilir)
SECRET_WORD: .data "MERHABA\0"

; Bulunan Harfler Dizisi
FOUND_LETTERS: .data 20 * 0

; Kelime (Ekran için)
WORD: .data 20 * 0

; Degiskenler
A0: .equ 0
A1: .equ 1
A2: .equ 2
A3: .equ 3
A6: .equ 6
D0: .equ 0
D1: .equ 1
D2: .equ 2
D3: .equ 3
D4: .equ 4
D5: .equ 5
D6: .equ 6
D7: .equ 7

; Sabitler
CR: .equ $0D
LF: .equ $0A

; Baslangiç Noktasi
START:

; Karsilama mesaji
LEA MSG_WELCOME, A1
MOVE.B #14, D0
TRAP #15

; A2'ye gizli kelimeyi yükle
LEA SECRET_WORD, A2

; A0'i sifirla
LEA FOUND_LETTERS, A0
MOVE.L #0, D7 ; Yanlis tahmin sayacini sifirla
CLR.L -(A0) ; FOUND_LETTERS dizisini sifirla
CLR.L -(A0)
CLR.L -(A0)
CLR.L -(A0)
LEA FOUND_LETTERS, A0 ; A0'i tekrar baslangica ayarla

; Ana döngüye gir
BRA MAIN_LOOP

; Ana Döngü
MAIN_LOOP:

; Kullanicidan harfi oku
JSR GET_CHARACTER
CMP.B #0, D1 ; Kullanicidan alinan girdinin sonunu kontrol et
BEQ END_GAME ; Eger sonu ise oyunu bitir

; Harfi gizli kelimede ara
MOVEA.L A2, A3
MOVE.B D1, D2
MOVEQ #0, D3

FIND_LETTER:
MOVE.B (A3), D4 ; A3'teki bayti D4'e yükle
CMP.B D4, D2 ; Harfi kontrol et
BEQ LETTER_FOUND

MOVEQ #0, D5 ; D5'e 0 yükle
CMP.B D4, D5 ; Gizli kelimenin sonunu kontrol et
BEQ LETTER_NOT_FOUND

ADDQ.L #1, A3 ; A3'ü arttir
BRA FIND_LETTER

LETTER_FOUND:
MOVE.B D4, (A0) ; Harfi FOUND_LETTERS dizisine ekle
ADDQ.L #1, A0 ; A0'yi bir sonraki pozisyona kaydir
BRA CHECK_GAME_STATUS

LETTER_NOT_FOUND:
ADDQ.L #1, D7 ; Yanlis tahmin sayisini arttir
CMP.L #6, D7 ; 6 yanlis tahmin
BEQ GAME_OVER

CHECK_GAME_STATUS:
; Mevcut durumu göster
JSR DISPLAY_WORD_STATUS

; Kelimeyi buldu mu kontrol et
CMP.B (A0), (A2)
BEQ GAME_WON

BRA MAIN_LOOP

; Oyun Bitti
GAME_OVER:
LEA MSG_GAME_OVER, A1
MOVE.B #14, D0
TRAP #15
BRA END_GAME

; Kelime Bulundu
GAME_WON:
LEA MSG_YOU_WIN, A1
MOVE.B #14, D0
TRAP #15
BRA END_GAME

; Oyun Sonu
END_GAME:
BRA END_GAME ; Sonsuz döngü

; Alt Rutinler

; String yazdirma alt rutini
PRINT_STRING:
  MOVE.B (A1)+, D1  ; A1'deki bir bayti al ve D1'e yükle
  BEQ PRINT_STRING_END  ; Eger bayt sifir ise döngüden çik
  MOVE.B D1, D0  ; D1'i yazdirma register'i (D0) olarak ata
  TRAP #15        ; Karakteri yazdir
  BRA PRINT_STRING  ; Döngüye devam et

PRINT_STRING_END:
  RTS              ; Alt rutinden çik
  
  END START

*~Font name~Courier New~
*~Font size~14~
*~Tab type~1~
*~Tab size~4~
