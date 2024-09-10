#include<stdio.h>
#include<locale.h>
int main(){
	setlocale(LC_ALL,"TURKISH");
	
	int a=10;
	int b=3, c=4;
	int x;
	printf("a: %d, b:%d, c:%d", a,b,c);
	printf("bir sayý giriniz:");
	scanf("%d",&x);
	printf("girilen sayý: %d", x);
	return 0;
	
}
