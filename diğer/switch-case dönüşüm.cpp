#include<stdio.h>
#include<stdlib.h>
#include<locale.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	double metre, sonuc;
	int secim;
	
	yeni_islem:
	printf("Metre cinsinden uzunlu�u giriniz.\n");
	scanf("%lf",&metre);
	
	yeni_secim:
	printf("L�tfen d�n��t�rmek istedi�iniz birimi se�iniz. \n1-mm\n2-cm\n3-dm\n4-km\n5-��k��\n");
	scanf("%d",&secim);
	
	
	switch (secim) {
		case 1:
			sonuc = metre * 1000;
			//break;
		case 2:
			sonuc = metre * 100;
			break;
		case 3:
			sonuc = metre * 10;
			break;
		case 4:
			sonuc = metre / 1000;
			break;
		case 5:
			exit(0);
		default:
			printf("Yanl�� se�im yapt�n�z. Se�im k�sm�na y�nlendiriliyorsunuz.\n");
			goto yeni_secim;
	}	
	printf("D�n��t�r�len de�er %.3lf\n",sonuc);
	
	printf("Ba�ka i�lem yapmak istiyor musunuz? Evet i�in 1'e bas�n�z. ��k�� i�in herhangi bir tu�a basabilirsiniz.\n");
	scanf("%d",&secim);
	if (secim==1)
		goto yeni_islem;
	
	return 0;
}
