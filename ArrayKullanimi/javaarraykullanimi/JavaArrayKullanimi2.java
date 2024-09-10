/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;
import java.util.Arrays;
import java.util.Scanner;
/**
 *
 * @author CASPER
 */
public class JavaArrayKullanimi2 {
    private static int [] arrayDondur(int a){
        Scanner scan = new Scanner(System.in);
        int [] cikti = new int[a];
        for (int i = 0;i<a;i++){
            System.out.print("Sayi "+i+" :");
            cikti[i]=scan.nextInt();
        }
        return cikti;
    }
    private static void bastir(int [] args){
        for(int arg : args){
            System.out.println(arg);
        }
    }
    private static void sirala(int [] args){
        Arrays.sort(args);
        bastir(args);
    }
    public static void main(String[] args) {
        int [] a = arrayDondur(6);
        bastir(a);
        System.out.println("----------------------------");
        sirala(a);
        
    }
}
