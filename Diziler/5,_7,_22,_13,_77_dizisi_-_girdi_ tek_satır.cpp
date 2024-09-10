#include <stdio.h>
int main(void){
	int dizi[5];
	for(int indis=0; indis<5; indis++){
		scanf("%d",&dizi[indis]);
	}
	for(int indis=0; indis<5; indis++){
		printf("%d", dizi[indis]);
	}
	return 0;
}
