//Birden 10'a kadar olan sayılarını toplamı
#include <stdio.h>
int main(){
    int t=1, tt=0, ttt=10;
    for (t; t<=ttt; t++){
        tt=tt+t;
        printf("%d : %d\n",t,tt);
    }
    /*
    t
    t=0						    =0
    t=0+1					    =1
    t=0+1+2					    =3
    t=0+1+2+3					=6
    t=0+1+2+3+4				    =10
    t=0+1+2+3+4+5				=15
    t=0+1+2+3+4+5+6			    =21
    t=0+1+2+3+4+5+6+7			=28
    t=0+1+2+3+4+5+6+7+8			=36
    t=0+1+2+3+4+5+6+7+8+9		=45
    t=0+1+2+3+4+5+6+7+8+9+10	=55
    */
    return 0;
}