/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package hastane.kayıt.programı;
import java.util.Arrays;
import java.util.Scanner;
//import sqlOptions.SQLConnectOption;

/**
 *
 * @author CASPER
 */
public class HastaneKayıtProgramı {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int counter = 3;
        System.out.println("Hastane Yönetim Uygulamasın Hoşgeldiniz\n\n");
        while(true){
            if (counter>0){
                System.out.println(counter>=3?"":("Kalan Giriş Hakkını: "+counter));
                System.out.print("Kullanıcı: ");
                String un = scan.nextLine();
                System.out.print("Parola: ");
                String pw = scan.nextLine();
                if (false){
//                  Oturum kontrolünün ardından main modülüne aktarılacak
//                  Kullanıcı bilgileri main modülüne aktarılmalı
                }
                else{
                    counter-=1;
                }
            }
            else{
                System.out.println("Giriş Hakkı Doldu");
                break;
            }
            
//            SQLConnectOption sqlc = new SQLConnectOption();
        }

    }
    
}
