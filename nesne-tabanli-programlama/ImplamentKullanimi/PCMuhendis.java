package ImplamentKullanimi;

import java.util.ArrayList;
/**
 *
 * @author Talha YAŞAR
 */
public class PCMuhendis implements Imuhendisi{
private boolean askerlik = false;
    private boolean sicil = false;
    private double mezuniyet_ortalamasi = 0.0;    
    private ArrayList<String> is_tecrubeleri = new ArrayList<String>();
    public void MAKMuhendisi(boolean a, boolean s, double o, ArrayList<String> t){
        this.askerlik = a;
        this.sicil = s;
        this.mezuniyet_ortalamasi=o;
        this.is_tecrubeleri = t;
    }
    @Override
    public void askerlik_durumu() {
         if (askerlik){
            System.out.println("Askerliği yapıldı");
        }
        else{
            System.out.println("Askerliği Yapılmadı");
        }
    }

    @Override
    public void sicil_kaydi() {
        if(sicil){
            System.out.println("Sicil Kaydı Temiz");
        }
        else {
            System.out.println("Sicil kaydı bulunmaktadır.");
        }
    }

    @Override
    public String mezuiyet_ortalamasi() {
        return "Mezuniyet Ortalaması: "+ mezuniyet_ortalamasi;
    }

    @Override
    public void is_tecrubesi() {
       is_tecrubeleri.forEach((action)->{
           System.out.println(action);
    });
    } 
}
