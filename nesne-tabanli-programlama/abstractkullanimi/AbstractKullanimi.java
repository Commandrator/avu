package abstractkullanimi;
public class AbstractKullanimi {
    public static void main(String[] args) {
        Kare kare =new Kare("kare", 2);
        kare.alan_hesapla();
        kare.cevre_hesapla();
        Daire daire = new Daire("Daire", 2);
        daire.alan_hesapla();
        daire.cevre_hesapla();
        Ucken ucken = new Ucken("Betülün kusursuz üçkeni", 3,5, 4 ,5);
        ucken.alan_hesapla();
        ucken.cevre_hesapla();
    }
}
