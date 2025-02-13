package galeri_demo;
public class TOFAS extends ARAC{
    private double masraflar;
    public TOFAS(String marka, double oran, double alisFiyati, double masraflar){
        super(marka, oran, alisFiyati);
        this.masraflar = masraflar;
    }
    @Override
    void satisFiyati() {
        System.out.println(
            "Marka: " + getMarka() + "\n" +
            "Alış Fiyatı: " + getAlisFiyati() + "\n" +
            "Kar oranılı satış: " + (getAlisFiyati()*(1 + getOran())) + "\n" +
            "Masraflar Dahil Fiyat: " + (getAlisFiyati()*(1 + getOran()) + masraflar) + "\n");
    }
}
