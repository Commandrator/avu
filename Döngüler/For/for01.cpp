#include <stdio.h>
#include <locale.h>
int main() {
	
	setlocale(LC_ALL, "Turkish"); 
	
	int baslangic;
	int bitis;
	
	printf("Ba�lang�� de�erini giriniz.\n");
	scanf("%d",&baslangic);
	
	printf("Biti� de�erini giriniz.\n");
	scanf("%d",&bitis);
 
	for (baslangic; baslangic <= bitis; baslangic++)
	{
		printf("%d ", baslangic);
	}
 }
