#include <stdio.h>

int main()
{
  int sayi;

  printf("Bir int sayi giriniz: ");
  scanf("%d", &sayi);

  if(sayi%2==0) {
    printf("Girdiðiniz sayý çift bir sayýdýr: %d\n", sayi);
    printf("Sayýnýn 3 katý: %d", 3 * sayi);
  }
  else {
    printf("Girdiðiniz sayý tek bir sayýdýr: %d\n", sayi);
    printf("Sayýnýn 2 katý: %d", 2 * sayi);
  }

  return 0;
}
