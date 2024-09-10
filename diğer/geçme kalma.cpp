#include <stdio.h>
#include <stdlib.h>
#include <iostream>
int main()
{
	
	int vize;
	int final;
	double ortalama;
	printf("Vize notunu giriniz: ");
	scanf("%d", &vize);
	printf("Final notunu giriniz: ");
	scanf("%d" , &final);
	ortalama=vize*0.4+final*0.6;
	printf("Ortalama %f :", ortalama);
	if(ortalama<50)
    printf("\nKaldýnýz.");
    else
    printf("\nGeçtiniz. Tebrikler.");
	return 0;
}
