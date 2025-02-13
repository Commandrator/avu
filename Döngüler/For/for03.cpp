#include <stdio.h>
#include <locale.h>
int main() {
	setlocale(LC_ALL, "Turkish"); 
	int vize,final;
 	for (int i=1; i <= 3; i++)
	{
		printf("%d. Öðrencinin Vize Notunu Giriniz.\n",i);
		scanf("%d",&vize);
		printf("%d. Öðrencinin Final Notunu Giriniz.\n",i);
		scanf("%d",&final);
		
		if((vize*0.4 + final*0.6) >= 50)
			printf("%d. Öðrenci Dersi %.2lf ile Geçmiþtir.\n\n",i,(vize*0.4 + final*0.6));
		else
			printf("%d. Öðrenci Dersi %.2lf ile Kalmýþtýr.\n\n",i,(vize*0.4 + final*0.6));	
	}
 }
