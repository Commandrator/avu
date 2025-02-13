#include <stdio.h>
int main(){
	int dizi[3][4]={
		{5,7,8,10},
		{20,3,19,55},
		{11,1,0,99}
		};
	printf("%d\n",dizi[1][1]);
	printf("%d\n", dizi[0][2]);
	for(int i=0;i<3;i++){
		for(int j=0;j<4;j++){
			printf("Dizi[%d][%d] = %d\n",i,j,dizi[i][j]);
		}
	}
}
