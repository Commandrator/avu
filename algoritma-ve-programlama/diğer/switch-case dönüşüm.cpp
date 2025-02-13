#include<stdio.h>
#include<stdlib.h>
#include<locale.h>
int main()
{
	setlocale(LC_ALL, "Turkish"); 
	double metre, sonuc;
	int secim;
	
	yeni_islem:
	printf("Metre cinsinden uzunluðu giriniz.\n");
	scanf("%lf",&metre);
	
	yeni_secim:
	printf("Lütfen dönüþtürmek istediðiniz birimi seçiniz. \n1-mm\n2-cm\n3-dm\n4-km\n5-Çýkýþ\n");
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
			printf("Yanlýþ seçim yaptýnýz. Seçim kýsmýna yönlendiriliyorsunuz.\n");
			goto yeni_secim;
	}	
	printf("Dönüþtürülen deðer %.3lf\n",sonuc);
	
	printf("Baþka iþlem yapmak istiyor musunuz? Evet için 1'e basýnýz. Çýkýþ için herhangi bir tuþa basabilirsiniz.\n");
	scanf("%d",&secim);
	if (secim==1)
		goto yeni_islem;
	
	return 0;
}
