#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include "hesaplama.h" // The library file is called using "library.h" if it is in the directory

int main() {
	char command[50];
	int x, y, islem=0;
	setlocale(LC_ALL,"Turkish");
	islem_sec:
	printf("Yap�lacak i�lemi:\n1-) Toplama\n2-) ��kartma\n> ");
	scanf("%d",&islem);
   	system("cls");
	if (islem==1){
		printf("1. Say�y�: ");
		scanf("%d",&x);
		printf("2. Say�y�: ");
		scanf("%d",&y);
		toplama(x,y);
   		system("cls");
	}
	if (islem==2) {
		printf("1. Say�y�: ");
		scanf("%d",&x);
		printf("2. Say�y�: ");
		scanf("%d",&y);
		cikartma(x,y);
   		system("pause &cls");
	}
	else {
		printf("��lem say�s�n� giriniz.\n");
	}
	goto islem_sec;

	return 0;
}
