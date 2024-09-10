/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package ders06;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.ListIterator;
/**
 *
 * @author CASPER
 */
public class ders02 {
    public static void main(String[] args) {
        //metod<Tür> obje = boş obje;
        ArrayList<String> diller=new ArrayList<String>();
        diller.add("Java");
        diller.add("Php");
        diller.add("javaScript");
        diller.add("C#");
        diller.add("Python");
        System.out.println("-".repeat(50));
        for (String dill:diller){
            System.out.println(dill);
        }
        System.out.println("-".repeat(50));
        // Liste sıralama işlemi için kullanılmaktadır
        ListIterator<String> iterator = diller.listIterator();
        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }
    }
}
