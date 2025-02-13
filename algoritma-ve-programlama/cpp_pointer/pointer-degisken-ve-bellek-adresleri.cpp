#include <stdio.h>
int main(){
	int *ip1, *ip2, id1, id2;
	ip1 = &id1;
	ip2 = &id2;
	*ip1 = 42;
	*ip2 = 67;
printf("id1 degiskeninin degeri: %d\n", *ip1);
printf("id2 degiskeninin değeri: %d\n", *ip2);
printf("id1 degiskeninin bellek adresi: %d\n", ip1);
printf("id1 degiskeninin bellek adresi: %d\n", ip2);
printf("\n\n");
printf("ip1 isaretcisinin bellek adresi: %p\n",&ip1);
printf("ip2 isaretcisinin bellek adresi: %p\n",&ip2);
return 0;
}
