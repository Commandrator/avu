#include <stdio.h>
int main(void){
	int dizi[]={2,4,3,10,11,16};
	int uzunluk=sizeof(dizi)/sizeof(int);
	printf("%d\n%d\n%d\n",sizeof(dizi),sizeof(int),uzunluk);
	int dizi2[uzunluk];
	for (int indis=0;indis<uzunluk;indis++)
		scanf("%d",&dizi[indis]);

	for (int indis=0;indis<uzunluk;indis++)
		printf("%d ",dizi[indis]);
	return 0;
}
