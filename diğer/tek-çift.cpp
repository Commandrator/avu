#include <stdio.h>

int main()
{
  int sayi;

  printf("Bir int sayi giriniz: ");
  scanf("%d", &sayi);

  if(sayi%2==0) {
    printf("Girdi�iniz say� �ift bir say�d�r: %d\n", sayi);
    printf("Say�n�n 3 kat�: %d", 3 * sayi);
  }
  else {
    printf("Girdi�iniz say� tek bir say�d�r: %d\n", sayi);
    printf("Say�n�n 2 kat�: %d", 2 * sayi);
  }

  return 0;
}
