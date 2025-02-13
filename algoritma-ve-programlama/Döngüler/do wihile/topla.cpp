#include <stdio.h>
using namespace std;

int main(){
	int toplam = 0, sayi, sayac = -1;
    do{
        printf("Bir sayı giriniz:");
        scanf("%d",&sayi);
        toplam += sayi;
        sayac++;
    }
    while (sayi !=0);9
    printf("Girdiginiz %d adet sayinin toplami %d dir", sayac, toplam);
	return 0;
}
