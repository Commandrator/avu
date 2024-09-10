package bankauygulamasi;

import java.util.ArrayList;

public class musteriOlustur implements musteriInterface {
    /**
     * Bir banka kullanıcılarının;
     * ad ve soyad,
     * şifre,
     * telefon,
     * bakiye
     * bilgileri listelenmek isteniyor.
     * Liste İnterface ile oluşturulması isteniyor.
     */
    private String adSoyad;
    private String sifre;
    private String telefon;
    private ArrayList<musteriHesapInterface> hesaplar = new ArrayList<>();
    @Override
    public void musteriOlustur(String adSoyad, String sifre, String telefon) {
        this.adSoyad = adSoyad;
        this.sifre = sifre;
        this.telefon = telefon;
    }
    
    @Override
    public void bilgiler() {
        System.out.print(adSoyad);
        System.out.print("\t");
        System.out.print(telefon);        
        System.out.print("\t");
        System.out.print(hesaplar.size());             
        System.out.print("\t");
        hesaplar.forEach((hesap) ->{
            hesap.hesap();
        });
    }
    @Override
    public void hesapOlustur(String birim) {
        musteriHesapInterface olustur = new musteriHesap();
        olustur.olustur(birim);
        hesaplar.add(olustur);
    }
    @Override
    public void bakiyeGuncelle(int hesapNumarasi, double bakiye, String islem) {
        switch(islem){
            case "yatri":
                hesaplar.get(hesapNumarasi).paraYatir(bakiye);
                break;
            case "cek":
                hesaplar.get(hesapNumarasi).paraCek(bakiye);
                break;
            default:
                System.out.println("Geçersiz İşlem");
                break;
        }
    }
}
