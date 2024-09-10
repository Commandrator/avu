#include <stdio.h>
#include <locale.h>

int main() {
	
	setlocale(LC_ALL, "Turkish"); 
	
	int top=0;
 
	for (int i=1; i<=5; i++)
	{
		printf("bir sayi girin");
		int sayi;
		scanf("%d",&sayi);
		top=top+sayi;
	}
	
	printf("Toplam: %d\n", top);

 }

