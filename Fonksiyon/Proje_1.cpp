#include <stdio.h>
#include <locale.h>
int toplamaFonksiyonu(int, int);
int main(void){ // void fonksiyon kullanýlacaðý anlamýna gelmektedir.
	setlocale(LC_ALL,"TURKISH");
	int sayi1, sayi2;
	sayi1=10;
	sayi2=20;
	printf("%d ve %d sayýlarýnýn toplamý = %d", sayi1, sayi2, toplamaFonksiyonu(sayi1, sayi2));
return 0;
}
int toplamaFonksiyonu(int sayi1, int sayi2){
	return sayi1+sayi2; // 
}
