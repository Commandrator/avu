package bankauygulamasi;
public interface musteriInterface {
    /**
     * Bir banka kullanıcılarının;
     * ad ve soyad,
     * şifre,
     * telefon,
     * bakiye
     * bilgileri listelenmek isteniyor.
     * Liste İnterface ile oluşturulması isteniyor.
     */
    void musteriOlustur(String adSoyad, String sifre, String telefon); 
    void hesapOlustur(String birim);   
    void bilgiler();
    void bakiyeGuncelle(int hesapNumarasi, double bakiye, String islem);
}
