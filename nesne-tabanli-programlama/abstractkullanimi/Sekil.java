package abstractkullanimi;
public abstract class Sekil {
    private String isim;
    public Sekil(String isism){
        this.isim = isism;
    }
    public void isnin_soyle(){
        System.out.println("Bu obje" + isim + "objesidir.");
    }
    abstract void alan_hesapla(); //Soyut Metod;
    abstract void cevre_hesapla();
    public String getIsim(){
        return isim;
    }
    public void setIsim(String isim){
        this.isim = isim;
    }
}
