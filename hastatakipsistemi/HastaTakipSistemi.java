package hastatakipsistemi;

import java.util.ArrayList;
import java.util.Scanner;
public class HastaTakipSistemi {
    public static void main(String[] args) {
        ArrayList<Hasta> hastalar = new ArrayList<Hasta>();
        Scanner scan = new Scanner(System.in);
        hastalar.add(new Hasta("Talha Yaşar"));
        while(true){
            System.out.print("1-) Hasta Ekle\n2-)Hasta Sayısı\n:");
            String opt = scan.next();
            switch(opt){
                case "1":
                    System.out.print("Hasta Adı:");
                    hastalar.add(new Hasta(scan.next()));
                    break;
                case "2":
                    System.out.println(hastalar.size());
                    break;
                default:
                    System.out.println("Hatalı İşlem");
                    break;
            }
        }
    }
}
