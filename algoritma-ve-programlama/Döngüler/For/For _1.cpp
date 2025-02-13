#include <stdio.h>
int main()
{ 
    int s,bs;
    printf("Baslangic degeri: ");
    scanf("%d",&s);
    printf("Bitis sayisi: ");
    scanf("%d",&bs);
    for(s; s<=bs; s++)
    {
        printf("\t %d", s);
    }
    return 0;
}