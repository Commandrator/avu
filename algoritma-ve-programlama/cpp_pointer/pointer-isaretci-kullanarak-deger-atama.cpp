#include<stdio.h>
int main()
{
	int *ip1,*ip2,id1,id2;
	
	ip1 = &id1;
	ip2 = &id2;
	id1 = 42;
	*ip2= 67;	
	
	printf("id1 de�i�keninin de�eri: %d\n", *ip1);
	printf("id2 de�i�keninin de�eri: %d\n", *ip2);
	printf("id1 de�i�keninin bellek adresi: %p\n", *ip1);
	printf("id2 de�i�keninin bellek adresi: %p", *ip2);
	printf("\n\n");
	printf("ip1 i�aretcinin bellek adresi: %p\n",&ip1);
	printf("ip2 i�aretcinin bellek adresi: %p",&ip2);
	return 0;
}
	
