/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package PrivateArrayClass;

/**
 *
 * @author CASPER
 */
public class testClass {
    private final String name;
    private final String surname;
    private final int age;

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @return the surname
     */
    public String getSurname() {
        return surname;
    }

    /**
     * @return the age
     */
    public int getAge() {
        return age;
    }
    public testClass(String name, String surname, int age){
        this.name = name;
        this.surname = surname;
        this.age = age;
    }
    public void writeUser(){
        System.out.println(String.format("%-20s %-10s %-3d", name, surname, age));
    }
}
