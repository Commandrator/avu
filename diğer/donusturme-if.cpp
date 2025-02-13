#include<stdio.h>
#include<stdlib.h>
#include<locale.h>
#include <math.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	int gun;
	
	
	printf("1-7 arasýnda bir deðer giriniz.\n");
	scanf("%d",&gun);
	
	if (gun==1)
		{
			printf("pazartesi");
		}
		
	if (gun==2) 
		{
			printf("salý");
		}
	if (gun==3)
		{
		printf("çarþamba");
		}
	if (gun==4)
		{
		printf("perþembe");
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
	{printf("Lütfen 1-7 arasýnda bir deðer giriniz!");
	}
	
}

