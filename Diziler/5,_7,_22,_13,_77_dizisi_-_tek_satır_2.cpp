#include <stdio.h>
#define DIZI_BOYUT 5
int main(void){
	int dizi[DIZI_BOYUT]={5,7,22,13,77};
	int uzunluk=sizeof(dizi)/sizeof(int);
	printf("%d\n", sizeof(dizi));
	printf("%d\n", sizeof(int));
	printf("%d\n", uzunluk);
	int dizi2[uzunluk];
	for(int indis=0; indis<uzunluk; indis++){
		scanf("%d", &dizi[indis]);
		}
	for(int indis=0; indis<uzunluk; indis++){
		printf("%d", dizi[indis]);
	}
}
