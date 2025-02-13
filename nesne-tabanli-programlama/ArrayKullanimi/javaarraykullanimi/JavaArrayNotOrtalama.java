/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;
import java.util.Scanner;
/**
 *
 * @author CASPER
 */
public class JavaArrayNotOrtalama {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.print("Vize: ");
        int v=scan.nextInt();
        System.out.print("Final: ");
        int f=scan.nextInt();
        float ort = get_ort(v,f);
        System.out.println("Ortalamanız: "+ort);
    }
    public static float get_ort(int y40, int y60) {
        // Ortalamayı ondalık sayı olarak hesapla
        return (float) (y40*0.4 + y60*0.6);
    }
}
