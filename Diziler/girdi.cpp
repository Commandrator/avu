#include <stdio.h>
#include <string.h>
#include <ctype.h>
#define DIZI_BOYUT 100
int main(void){
	char dizi[DIZI_BOYUT];
	int indis;
	yeni_deger:
		gets(dizi);
		for(indis=0; indis<strlen(dizi); indis++){
			printf("Sadece sayi giriniz.\n");
			goto yeni_deger;
		}
}
