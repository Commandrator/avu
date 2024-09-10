#include<stdio.h>
int main()
{
	int *ip1,*ip2,id1,id2;
	
	ip1 = &id1;
	ip2 = &id2;
	id1 = 42;
	*ip2= 67;	
	
	printf("id1 deðiþkeninin deðeri: %d\n", *ip1);
	printf("id2 deðiþkeninin deðeri: %d\n", *ip2);
	printf("id1 deðiþkeninin bellek adresi: %p\n", *ip1);
	printf("id2 deðiþkeninin bellek adresi: %p", *ip2);
	printf("\n\n");
	printf("ip1 iþaretcinin bellek adresi: %p\n",&ip1);
	printf("ip2 iþaretcinin bellek adresi: %p",&ip2);
	return 0;
}
	
