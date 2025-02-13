/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ListeKullanimi;

import java.util.ArrayList;

/**
 *
 * @author CASPER
 */
public class TestList{
    //function(Metod<Type>object)
    public static void print(ArrayList<String>arraylist){
        arraylist.forEach((doc)->{
            System.out.println("metod: "+ doc);
        });
    }
    public static void main(String[] args) {
        
        
        //ArrayList kullanımı:
        //Eleman listelemek için kullanılan ve util kütüphanesine ait bir sınıftır
        ArrayList<String> arraylist=new ArrayList<String>();
        arraylist.add("Ordu");
        arraylist.add("Trabzon");
        arraylist.add("Ankara");
        arraylist.add("Konya");
        arraylist.add("Rize");
        
        
        //index ile listeden item getirme:
        System.out.println("arraylsit.get(0): "+ arraylist.get(0));
       
        
        //index ile listeden item silme:
        System.out.println("Kaldırılmadan önce [3]:"+arraylist.get(3));
        arraylist.remove(3);
        System.out.println("Kaldırdıktan sonra [3]:"+arraylist.get(3));
        
        
        //Array boyutunu hesaplama
        int size = arraylist.size();
        System.out.println("ArraySize(): "+ size);
        
        
        //ArrayList for kullanımı:
        for (int i =0; i<arraylist.size();i++){
            System.out.println("for: "+ i + " " +arraylist.get(i));
        }
        
        
        //ArrayList forEach kullanımı:
        arraylist.forEach((doc)->{
            System.out.println("forEach: "+ doc);
        });
        
        
        //ArrayList indexOf kullanımı:
        //Array'de aranan ilk ifadeyi getirir.
        int findedIndex = arraylist.indexOf("Trabzon");
        System.out.println(findedIndex);
        
        
       
        //ArrayList lastIndexOf kullanımı:
        //Array'de aranan son ifadeyi bulmaya yarar.
        int findedLastIndex = arraylist.lastIndexOf("Trabzon");
        System.out.println("lastIndexOf('Trabzon'): "+findedLastIndex);
        
        
        //ArrayList set kullanımı:
        //Listedeki veriyi güncellemek için kullanılır.        
        System.out.println("Güncellemeden önce: "+ arraylist.get(1));
        arraylist.set(1, "Kastamonu");
        System.out.println("Güncellemeden sonra: "+ arraylist.get(1));
        
        //Sınıf ile yazdırma işlemi
        print(arraylist);
    }
}
