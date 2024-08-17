*-----------------------------------------------------------
* Title      : Vize Final Hesaplam Program?
* Written by : Talha Ya?ar
* Date       : 07/06/2024 - 02:05
* Description: Girilen n'tane vize puan? ve final puan?'n?n yüzdelerine göre hesaplama
*-----------------------------------------------------------
    ORG    $1000
START:
    BRA     Program		;Program ba?lat?ld?

Loop:
    JSR     GetChar		;Program i?lemi için kullan?c?dan girdi alma fonksiyonu ça??r?ld?
    BRA     CheckChoice	;Giridinin kar??la?t?r?laca?? Fonksiyon
    
VizeSayisiSec:
        LEA     VizeSayisi,A1	;Ekrana yazd?r?lacak yaz?, kullan?c?ya kaç tane vize girece?ini belirtecek
        MOVE.B  #14,D0
        TRAP    #15
        
        MOVE.B  #5,D0
        TRAP    #15
        
        MOVE.B  D1,D5
        RTS

GetChar:
        LEA     ChooseOption,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        MOVE.B  #5,D0
        TRAP    #15
        
        MOVE.B  D1,D4
        RTS

CheckChoice:

        * D4'teki karakte 1 ise program? çal?t?r
        CMP.B   #$31,D4
        BEQ     Program
        
        * Karakte 0 ise pogram? sonland?r.
        CMP.B   #$30,D4
        BNE     Loop
        BEQ     FINISH

Program:    
	JSR     VizeSayisiSec
	BRA     Function
		
Function:  
        * Get Values
        JSR     GetNumbersVize
        * Virgüllü sar assamly üzerinde çal?m?yor. bu üyzden hassas yakla??m ile hesap ya?lmas? öneriliyor
        * vize * (yüzde / 100 ) i?lem, yüzde/100 i?leminin 0 sonucunu ç?karmas?ndan dolay? 0 sonucu dönecektir.
        * vize ve yüzdenin çarp?m?n?n bölümü kullan?lan denklem için sonucu etkilemedi?i için tercih edilmesi daha do?ru bir yakla??m olucakt?r.
        * bu durumda denklem (vize * yüzde)/100 haline gelecektir.
        * D3 = D3 * D2, vize ve yüzdeyi çarp
        * d0 = 100, d0'a 100 de?erini ata
        * D2 = D2 / D0, sonucu d0'a böl
        
        * MULS.W  D3,D2   ;d3 ile d2 yi çarp  
        * MOVE.W  #100,D0 ;0'a 100 ata
        * DIVS.W  D0,D2   ;d2'yi d0'daki de?ere böl
        
        * Bu yakla??m küsüratl? olmayan say?lar (vize:70, final:40; sonuç 28) için istenilen gibi çal??sa da küsüratl? say?larda istenilen gibi çal??mamktad?r.                
        
		MULS.W  D3,D2   ;d3 ile d2 yi çarp  
		MOVE.W  #100,D0 ;0'a 100 ata
		DIVS.W  D0,D2   ;d2'yi d0'daki de?ere böl

        * Display result in console
*        LEA     Result,A1
*        MOVE.B  #14,D0
*        TRAP    #15  
*        
*        MOVEQ   #3,D0
*        MOVE.B  D2,D1
*        TRAP    #15
       	ADD.B	D2,D6
      	SUBQ.B  #1,D5   ; D5 kaydindan 1 çikar
      	
       	CMP.B   #$30,D5
       	BEQ     Final   ; 0 ise Final'e git
		BRA     Function ; de?il ise i?lemi tekrarla



Final:
		JSR     GetNumbersFinal
		MULS.W  D3,D2   ;d3 ile d2 yi çarp  
		MOVE.W  #100,D0 ;0'a 100 ata
		DIVS.W  D0,D2   ;d2'yi d0'daki de?ere böl
		ADD.B	D6, D2
       	LEA     Result,A1
       	MOVE.B  #14,D0
       	TRAP    #15  
        
       	MOVEQ   #3,D0
       	MOVE.B  D2,D1
       	TRAP    #15
        
		BRA     Loop

		
FINISH:
        LEA     EndProgram,A1 ; Sonalanmadan önce ekran mesaj bast?racak
        MOVE.B  #14,D0
        TRAP    #15 
        SIMHALT
      
GetNumbersVize:
        LEA     NumberPrompt1Vize,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        * Trap 4 Task - Read the first number from keyboard into D1.L
        MOVE.B  #4,D0      
        TRAP    #15
        
        * Girdiyi d2'de sakla
        MOVE.B  D1,D2      
        
        * Prompt the user for their second number
        LEA     NumberPrompt2Vize,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        * Trap 4 Task - Read the first number from keyboard into D1.L
        MOVE.B  #4,D0      
        TRAP    #15
        
        * girditi d3'te sakla
        MOVE.B  D1,D3
        RTS 
   
GetNumbersFinal:
        
        * Prompt the user for their first number
        LEA     NumberPrompt1Final,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        * Trap 4 Task - Read the first number from keyboard into D1.L
        MOVE.B  #4,D0      
        TRAP    #15
        
        * Girdiyi d2'de sakla
        MOVE.B  D1,D2      
        
        * Prompt the user for their second number
        LEA     NumberPrompt2Final,A1
        MOVE.B  #14,D0
        TRAP    #15
        
        * Trap 4 Task - Read the first number from keyboard into D1.L
        MOVE.B  #4,D0      
        TRAP    #15
        
        * girditi d3'te sakla
        MOVE.B  D1,D3
        RTS    


* ASCII Code for Carriage Return (CR) and Line Feed (LF)
CR      EQU     $0D
LF      EQU     $0A

NumberPrompt1Vize:		DC.B    CR,LF,'Vize notu: ',0
NumberPrompt2Vize:		DC.B    CR,LF,'Vize Yüzdesi: ',0
NumberPrompt1Final:		DC.B    CR,LF,'Final notu: ',0
NumberPrompt2Final:		DC.B    CR,LF,'Final Yüzdesi: ',0
ChooseOption:    	 	DC.B    CR,LF,'Yeniden not hesaplamak için (1), Çikmak için (0) tusuna basin:',0
Result:             	DC.B    CR,LF,'Sonuç: ',0
VizeSayisi:         	DC.B    CR,LF,'Girilecek Vize Sayisi:',0
EndProgram:         	DC.B    CR,LF,'Program sonlandirildi.',0


        END    START        ; last line of source
*~Font name~Courier New~
*~Font size~14~
*~Tab type~1~
*~Tab size~4~
