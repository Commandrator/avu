package abstractkullanimi;
/**
 *
 * @author Talha YAŞAR
 */
public class Kare extends Sekil{

    private int alan;
    public Kare(String isism, int alan) {
        super(isism);
        this.alan = alan;
    }

    @Override
    void alan_hesapla() {
        System.out.println(getIsim() + " Alanı:" + (Math.pow(alan, 2)));
    }

    @Override
    void cevre_hesapla() {
        System.out.println(getIsim() + " Çevresi:" +(alan * 4));
    }
    
}
