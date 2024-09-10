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
public class javaArrayMetodlarlaOrtalama {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.print("Dizi Boyutu Girin: ");
        int boyut = scan.nextInt();
        int[] array = new int[boyut];

        for (int i = 0; i < array.length; i++) {
            System.out.print("array[" + i + "]= ");
            int deger = scan.nextInt();
            array[i] = deger;
        }
        float ort = get_ort(array);
        System.out.println("Ortalama: " + ort);

        // Scanner'ı kapat
        scan.close();
    }

    public static float get_ort(int arg[]) {
        int ort_data = 0;
        for (int i = 0; i < arg.length; i++) {
            ort_data += arg[i];
        }
        // Ortalamayı ondalık sayı olarak hesapla
        return (float) ort_data / arg.length;
    }
}
