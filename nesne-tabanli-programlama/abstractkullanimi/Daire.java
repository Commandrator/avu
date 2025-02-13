/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package abstractkullanimi;

/**
 *
 * @author CASPER
 */
public class Daire extends Sekil {
    private int yariCap;
    public Daire(String isism, int yariCap) {
        super(isism);
        this.yariCap = yariCap;
    }

    @Override
    void alan_hesapla() {
        System.out.println(getIsim() + " Alanı:" + (Math.PI * Math.pow(yariCap, 2)));
    }

    @Override
    void cevre_hesapla() {
        System.out.println(getIsim() + " Çevre:" + (2* Math.PI * yariCap));
    }
}
