package loginapp;
import java.util.Scanner;

public class LoginApp {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Kullanıcı Adı: ");
        String username = scan.next();

        System.out.print("Şifre: ");
        String password = scan.next();

        boolean isAuthenticated = isExists(username, password);

        if (isAuthenticated) {
            System.out.println("Giriş başarılı!");
        } else {
            System.out.println("Geçersiz kullanıcı adı veya şifre.");
        }
    }
    public static boolean isExists(String u, String p) {
        String[] users = {"Fatm_Nur", "Özlem", "Merve"};
        String[] pass = {"6161", "7262", "5353"};

        int index = 0;
        for (String user : users) {
            if (user.equals(u)) {
                if (pass[index].equals(p)) {
                    return true;
                }
            }
            index++;  
        }
        return false; 
    }
}
