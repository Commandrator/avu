#include<stdio.h>
#include<locale.h>
#include <math.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	int sayi, sonuc, birler, onlar, yuzler;
	
	printf("Rakamlar� toplanacak pozitif say�y� giriniz. (En B�y�k 999)\n");
	scanf("%d",&sayi);
	
	yuzler = sayi / 100;
	onlar = (sayi % 100) /10;
	birler = sayi % 10;
	
	sonuc = yuzler + birler + onlar;
		
	printf("%d\n",sonuc);

	return 0;
}
