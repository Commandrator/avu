#include <stdio.h>
#include <locale.h>
int main() {
	setlocale(LC_ALL, "Turkish"); 
	int vize,final;
 	for (int i=1; i <= 3; i++)
	{
		printf("%d. ��rencinin Vize Notunu Giriniz.\n",i);
		scanf("%d",&vize);
		printf("%d. ��rencinin Final Notunu Giriniz.\n",i);
		scanf("%d",&final);
		
		if((vize*0.4 + final*0.6) >= 50)
			printf("%d. ��renci Dersi %.2lf ile Ge�mi�tir.\n\n",i,(vize*0.4 + final*0.6));
		else
			printf("%d. ��renci Dersi %.2lf ile Kalm��t�r.\n\n",i,(vize*0.4 + final*0.6));	
	}
 }
