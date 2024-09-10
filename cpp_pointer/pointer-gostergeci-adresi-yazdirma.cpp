#include <stdio.h>
#include <locale.h>

int main() {
    setlocale(LC_ALL, "Turkish");
    int *ip;
    int idizi[5] = {5, 17, 21, 34, 46};
    int id;
    printf("İşaretçinin bellekteki adresi: %p\n\n", (void*)&ip);
    ip = idizi; // ip = &idizi[0];
    for (id = 0; id < 5; id++) {
        printf("idizi[%d] = %d, adresi: %p\n", id, *(ip + id), (void*)&idizi[id]);
    }
    return 0;
}
