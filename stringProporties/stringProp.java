package stringProporties;
/**
 *
 * @author Talha YAŞAR
 */
public class stringProp {
    public static void main(String[] args) {
        //String ile ilgiil olan metodlar
        String text = "Talha";
        System.out.println(String.format("Boyutu: %d",text.length()));        
        System.out.println(String.format("T ile başlıyor: %b",text.startsWith("T")));
        System.out.println(String.format("a ile biyiyor: %b",text.endsWith("a")));
        for(int i=0;i<text.length();i++){
            System.out.println(String.format("index: %d, karakter: %c", i, text.charAt(i)));
        }
    }
}
