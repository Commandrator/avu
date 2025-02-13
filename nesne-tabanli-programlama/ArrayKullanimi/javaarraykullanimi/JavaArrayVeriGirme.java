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
public class JavaArrayVeriGirme {
    public static void main(String[] args){
        Scanner scan = new Scanner(System.in);
        int [] a = new int[5];
        for (int i=0;i<5;i++){
            System.out.println("Lütfen dizi için bir eleman belirleyiniz.");
            a[i]=scan.nextInt();
            System.out.println("Dizi için belirlenen elemen " +a[i]);
        }
    }
}
