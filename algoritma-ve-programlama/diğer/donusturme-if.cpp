#include<stdio.h>
#include<stdlib.h>
#include<locale.h>
#include <math.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	int gun;
	
	
	printf("1-7 aras�nda bir de�er giriniz.\n");
	scanf("%d",&gun);
	
	if (gun==1)
		{
			printf("pazartesi");
		}
		
	if (gun==2) 
		{
			printf("sal�");
		}
	if (gun==3)
		{
		printf("�ar�amba");
		}
	if (gun==4)
		{
		printf("per�embe");
		}
	if (gun==5)
		{
		printf("cuma");
		}
	if (gun==6)
		{
		printf("cumartesi");
		}
	if (gun==7)
		{
		printf("pazar");
		}
	
	else
	{printf("L�tfen 1-7 aras�nda bir de�er giriniz!");
	}
	
}

