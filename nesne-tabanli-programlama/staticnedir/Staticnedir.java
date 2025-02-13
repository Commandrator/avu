package staticnedir;
public class Staticnedir {
    public static void main(String[] args) {
        Seyirci seyirci = new Seyirci("Talha Yaşar");
        System.out.println(seyirci.getSeyirci());
        selam();
    }    
    private static void selam(){
        System.out.println("Selam.");
    }
}
