#include <stdio.h>
#include <locale.h>
int main() {
	
	setlocale(LC_ALL, "Turkish"); 
	
	int baslangic;
	int bitis;
	
	printf("Baþlangýç deðerini giriniz.\n");
	scanf("%d",&baslangic);
	
	printf("Bitiþ deðerini giriniz.\n");
	scanf("%d",&bitis);
 
	for (baslangic; baslangic <= bitis; baslangic++)
	{
		printf("%d ", baslangic);
	}
 }
