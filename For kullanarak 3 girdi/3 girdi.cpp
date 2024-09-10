#include <stdio.h>
int main(){
    int vize, final;
    float ort;
    for (int i=0; i < 3; i++)
    {
        printf("Vize Notu girin:");
        scanf("%d",&vize);
        printf("Final Notu Girin:");
        scanf("%d",&final);
        ort = (vize*0.4+final*0.6);
        if ( ort >= 50)
            printf("%d. Öğrenci dersi %.2lf ile Geçmiştir. \n\n",i,ort);
        else
            printf("%d. Öğrenci dersi %.2lf ile kalmıştır. \n\n",i,ort);
    }
    return 0;
}