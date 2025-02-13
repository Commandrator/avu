/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;

/**
 *
 * @author CASPER
 */
public class JavaArrayStringArrayKullanımı {
    public static void main(String[] args) {
        String users [] = {"umut","ayşe","fatmanur","ali","betül"};
        printUser(users);
    }
    public static void printUser(String[] args){
        System.out.println("Öğrenci\n---------");
        for (int i=0;i<args.length;i++){
            System.out.println(i+". "+args[i]);
        }
    }
}
