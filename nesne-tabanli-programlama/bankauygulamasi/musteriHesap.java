package bankauygulamasi;
public class musteriHesap implements musteriHesapInterface {
    private String birim;
    private double bakiye;
    public double bakiye(){
        return bakiye;
    }
    public void hesap(){
        System.out.print("Birim:");
        System.out.print(birim);        
        System.out.print("\t");
        System.out.print( "Bakiye:");
        System.out.print("\t");
        System.out.print(bakiye);
    }
    public void paraYatir(double bakiye){
        this.bakiye += bakiye;
    }
    public void paraCek(double bakiye){
        this.bakiye -= bakiye;
    }
    public void olustur(String birim){
        this.birim = birim;
        this.bakiye =0;
    }
}
