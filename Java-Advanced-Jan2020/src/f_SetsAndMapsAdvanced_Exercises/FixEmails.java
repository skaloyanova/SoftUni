package f_SetsAndMapsAdvanced_Exercises;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class FixEmails {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String,String> mails = new LinkedHashMap<>();

        String name = sc.nextLine();
        while (!"stop".equals(name)) {
            String email = sc.nextLine();
            int lastDot = email.lastIndexOf('.');
            String domain = email.substring(lastDot + 1);
            if (!"uk".equalsIgnoreCase(domain) && !"com".equalsIgnoreCase(domain) && !"us".equalsIgnoreCase(domain)) {
                mails.put(name, email);
            }
            name = sc.nextLine();
        }
        mails.forEach((k,v) -> System.out.println(k + " -> " + v));
    }
}
