/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package javaarraykullanimi;

/**
 *
 * @author CASPER
 */
public class JavaCokluArrayKullanimi {
    public static void main(String[] args) {
        int multipleArray[][] = new int[5][4];
        multipleArray[0][0] = 123;
        multipleArray[0][1] = 123;
        multipleArray[0][2] = 123;
        multipleArray[0][3] = 123;
        multipleArray[1][0] = 123;
        multipleArray[2][1] = 123;
        multipleArray[3][2] = 123;
        multipleArray[4][3] = 123;
        for (int[] row : multipleArray) {
            System.out.println("ROW\n-------------------------------");
            for (int cell : row) {
                System.out.println("cell: " + cell);
            }
        }

    }
}
