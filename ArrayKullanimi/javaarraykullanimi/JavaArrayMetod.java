/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;

/**
 *
 * @author CASPER
 */
public class JavaArrayMetod {
    public static void array_bastir(int[]args){
        for (int i=0;i<args.length;i++){
            System.out.println("Element " + (i+1) + ":" + args[i]);
        }
    }
    public static void ortalama_bastir(int[]args){
        int toplam=0;
        for (int i=0;i<args.length;i++){
            toplam+=args[i];
        }
        System.out.println("Ortalama:"+((double)toplam/args.length));
    }
    public static void main(String[] args) {
        int [] a = {32,45,676,78,754,2,4};
        System.out.println("Array uzunluğu:" + a.length);
        ortalama_bastir(a);
        array_bastir(a);
    }
}
