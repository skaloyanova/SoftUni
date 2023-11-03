package Final2019_12_07_gr1;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Registration {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        final String REGEX = "U\\$(?<user>[A-Z][a-z]{2,})U\\$P@\\$(?<pass>[A-Za-z]{5,}\\d+)P@\\$";
        Pattern pattern = Pattern.compile(REGEX);

        int count = 0;

        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();

            Matcher matcher = pattern.matcher(input);

            if (matcher.find()) {
                String username = matcher.group("user");
                String password = matcher.group("pass");

                System.out.println("Registration was successful");
                System.out.println(String.format("Username: %s, Password: %s", username, password));
                count++;
            } else {
                System.out.println("Invalid username or password");
            }
        }

        System.out.println("Successful registrations: " + count);
    }
}
