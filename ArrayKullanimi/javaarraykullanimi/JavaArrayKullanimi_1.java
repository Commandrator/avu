/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;

/**
 *
 * @author CASPER
 */
public class JavaArrayKullanimi_1 {
    public static void main(String[] args) {
        String [] Array = {"Elma","Armut", "Kiraz", "Çilek", "Erik", "Portakal"};
        //For döngüsü kullanımı
        System.out.println("For ile kullanım");
        for (int i=0;i<Array.length;i++){
            System.out.println(Array[i]);
        }
        System.out.println("ForEach ile kullanım");
        //ForEach
        for (String item : Array){
            System.out.println(item);
        }
        
    }
}
