package abstractkullanimi;
/**
 *
 * @author Talha YAŞAR
 */
public class Ucken extends Sekil{
    private float x, y ,z;
    private float yukseklik;
    
    public Ucken(String isism, float yukseklik, float x , float y, float z) {
        super(isism);
        this.x = x;
        this.y = y;
        this.z = z;
        this.yukseklik = yukseklik;
    }
    @Override
    void alan_hesapla() {
        System.out.println(getIsim() + " Alanı:" + ((yukseklik * x ) /2));
    }    

    void cevre_hesapla() {
        System.out.println(getIsim() + " Çevre:" + (x + y + z));
    }
}
