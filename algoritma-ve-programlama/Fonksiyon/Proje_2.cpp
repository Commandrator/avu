#include <stdio.h>
#include <locale.h>
int toplamaFonksiyonu(int, int);
int main(void){ // void fonksiyon kullan�laca�� anlam�na gelmektedir.
	setlocale(LC_ALL,"TURKISH");
	int sayi1, sayi2;
	printf("Say�1:");
	scanf("%d",&sayi1);
	
	printf("Say�2:");
	scanf("%d",&sayi2);
	printf("%d ve %d say�lar�n�n toplam� = %d", sayi1, sayi2, toplamaFonksiyonu(sayi1, sayi2));
return 0;
}
int toplamaFonksiyonu(int sayi1, int sayi2){
	return sayi1+sayi2; 
}
