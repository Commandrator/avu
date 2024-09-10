/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;
import java.util.Arrays;
/**
 *
 * @author CASPER
 */
public class JavaArraySortKullanimi {
    private static void array_yazdir(int args[]){
        for (int data:args){
            System.out.println(data);
        }
    }
    private static void array_sort(int args[]){
        Arrays.sort(args);
        array_yazdir(args);
    }
    public static void main(String[] args) {
        int t [] = {1,23,45,67,234,56,78,654,321,2345,67,865,4321,2};
        int p [] = {1,23,45,67,234,56,78,654,321,2345,67,865,4321,2};
        if (Arrays.equals(t,p)){
            System.out.println("Diziler Eşit");
        }
        else{
            System.out.println("Eşit Değil");
        }
        array_sort(t);
    }
}
