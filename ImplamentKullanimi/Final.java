package ImplamentKullanimi;

import java.util.ArrayList;

/**
 *
 * @author Talha YAŞAR
 */
public class Final {
    public static void main(String[] args) {
        ArrayList<String> list = new ArrayList<String>();
        list.add("Test");
        MAKMuhendisi mühendis = new MAKMuhendisi(false, false, 3.9, list);
        mühendis.is_tecrubesi();
    }
}
