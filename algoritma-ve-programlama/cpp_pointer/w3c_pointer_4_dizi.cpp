#include <stdio.h>
#include <locale.h>
int main() {
setlocale(LC_ALL, "TURKISH");
  int i, s, myNumbers[4] = {25, 50, 75, 100};
  printf("4 Say� gir");
  scanf("%d",&s);
  for (i = 0; i < 4; i++) {
    printf("%d\t%p\n",myNumbers[i], &myNumbers[i]);
  }
  return 0;
}
