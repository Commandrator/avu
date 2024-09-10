package bankauygulamasi;

import java.util.ArrayList;

public class BankaUygulamasi {
    /**
     * Bir banka kullanıcılarının;
     * ad ve soyad,
     * şifre,
     * telefon,
     * bakiye
     * bilgileri listelenmek isteniyor.
     * Liste İnterface ile oluşturulması isteniyor.
     */
    public static void main(String[] args) {
       ArrayList<musteriInterface> musteriler = new ArrayList<>();
       musteriInterface musteriOlustur = new musteriOlustur();
       musteriOlustur.musteriOlustur("Talha Yaşar", "Talha123", "05398906152");
       musteriOlustur.hesapOlustur("TL");
       musteriOlustur.bakiyeGuncelle(0, 100, "yatri");
       musteriOlustur.hesapOlustur("USD");       
       musteriOlustur.bakiyeGuncelle(1, 100, "yatri");
       musteriler.add(musteriOlustur);
       musteriler.get(0).bilgiler();
    }
    
}
