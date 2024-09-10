package galeri_demo;
public abstract class ARAC {
    private String marka;
    private double oran;
    private double alisFiyati;
    ARAC(String marka, double oran, double alisFiyati){
        this.marka = marka;
        this.oran = oran;
        this.alisFiyati = alisFiyati;
    }
    abstract void satisFiyati();
    public String getMarka() {
        return marka;
    }
    public double getOran() {
        return oran;
    }
    public double getAlisFiyati() {
        return alisFiyati;
    }
}
