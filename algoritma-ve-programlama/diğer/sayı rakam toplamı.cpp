#include<stdio.h>
#include<locale.h>
#include <math.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	int sayi, sonuc, birler, onlar, yuzler;
	
	printf("Rakamlarý toplanacak pozitif sayýyý giriniz. (En Büyük 999)\n");
	scanf("%d",&sayi);
	
	yuzler = sayi / 100;
	onlar = (sayi % 100) /10;
	birler = sayi % 10;
	
	sonuc = yuzler + birler + onlar;
		
	printf("%d\n",sonuc);

	return 0;
}
