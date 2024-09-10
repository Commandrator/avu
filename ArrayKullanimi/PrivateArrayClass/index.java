/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package PrivateArrayClass;

/**
 *
 * @author CASPER
 */
public class index {
    public static void main(String[] args) {
        testClass[] array= {new testClass("talha", "yaşar", 21), new testClass("Taha ismail","Engin", 24)};
        //Table Head
        //String format kullanımı
        //%<boşluk><ver_türü>
        //
        //%a	floating point (except BigDecimal)	Returns Hex output of floating point number.
        //%b	Any type	"true" if non-null, "false" if null
        //%c	character	Unicode character
        //%d	integer (incl. byte, short, int, long, bigint)	Decimal Integer
        //%e	floating point	decimal number in scientific notation
        //%f	floating point	decimal number
        //%g	floating point	decimal number, possibly in scientific notation depending on the precision and value.
        //%h	any type	Hex String of value from hashCode() method.
        //%n	none	Platform-specific line separator.
        //%o	integer (incl. byte, short, int, long, bigint)	Octal number
        //%s	any type	String value
        //%t	Date/Time (incl. long, Calendar, Date and TemporalAccessor)	%t is the prefix for Date/Time conversions. More formatting flags are needed after this. See Date/Time conversion below.
        //%x	integer (incl. byte, short, int, long, bigint)Hex string.
        System.out.println(String.format("%-20s %-10s %s", "İsim", "Soyisim", "yaş"));
        for (testClass user:array){
            user.writeUser();
        }
    }
}
