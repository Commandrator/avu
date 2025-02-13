/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ders06;

/**
 *
 * @author CASPER
 */
public class ders01 {
    public static void main(String[] args) {
        String x="";
        int count=0;
        String a = "Mustafa";
        String b = new String("Mustafa");
        count =50;
        x="-".repeat(count);
        System.out.println(x);
        x=a;
        System.out.println(x);
        x=b;
        System.out.println(x);
        x="-".repeat(count);
        System.out.println(x);
        x="Harf sayısı: "+a.length();
        System.out.println(x);
        x="-".repeat(count);
        System.out.println(x);
        int index = 0;
        x="0.Index: "+a.charAt(index);
        System.out.println(x);
        index=5;
        x="5.Index: "+b.charAt(index);
        System.out.println(x);
        
        for (int i=0;i<b.length();i++){
            index = i;
            System.out.println(i+1 +"-) "+b.charAt(index));
        }            
        x="-".repeat(count);
        System.out.println(x);
        //İle bbaşlıyor
        String prefix = "Mus";
        System.out.println(b.startsWith(prefix));
        //İle sonlanıyor
        String suffix = "fa";
        System.out.println(b.endsWith(suffix));
        //indexinden başlıyor
        String str = "taf";
        System.out.print("İndex Numarası: ");
        System.out.print(b.indexOf(str));
    }
}
