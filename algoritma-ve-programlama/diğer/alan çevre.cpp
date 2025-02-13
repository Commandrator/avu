#include <stdio.h>

int main(){
	int daireYaricap;
	float pi=3.14, daireAlan, daireCevre;

     
	printf("Dairenin yaricapini giriniz : "); 
	scanf("%d",&daireYaricap);

 
	daireAlan = pi * daireYaricap * daireYaricap; 
	printf("Dairenin alani : %f \n",daireAlan);

	daireCevre = 2 * pi * daireYaricap;     
	printf("Dairenin cevresi : %f", daireCevre);
}
