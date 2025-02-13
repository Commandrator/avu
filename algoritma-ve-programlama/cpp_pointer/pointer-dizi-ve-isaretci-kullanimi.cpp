#include<stdio.h>
int main()
{
	int *ip;
	int idizi[5]={5,17,21,34,46};
	int id;
	
printf("Isaretci bellek adresi: %p\n\n", &ip);

	ip=idizi;// ip=&idizi[0];
	
	for(id=0;id<5;id++,ip++)
	{
		printf("Isaretcinin icerdigi bellek adresi: %p %p\n",ip,&idizi[id]);
		printf("Isaretcinin gosterdigi degisken degeri: %d %d\n\n",ip,idizi[id]);
	}
	return 0;
}
	
