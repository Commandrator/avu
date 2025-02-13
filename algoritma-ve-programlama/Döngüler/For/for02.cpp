#include <stdio.h>
#include <locale.h>
int main() {
	
	setlocale(LC_ALL, "Turkish"); 
	
	int baslangic = 0;
	int bitis = 10;
	int toplam=0;
 
	for (baslangic; baslangic <= bitis; baslangic++)
	{
		printf("%d\n",baslangic);
		toplam+=baslangic;
	}
	
	printf("Toplam: %d", toplam);
 }
