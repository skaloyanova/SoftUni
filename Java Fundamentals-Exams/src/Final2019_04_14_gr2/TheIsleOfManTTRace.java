package Final2019_04_14_gr2;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class TheIsleOfManTTRace {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        final String REGEX = "([#$%*&])(?<name>[A-Za-z]+)\\1=(?<length>[0-9]+)!!(?<code>.+)";
        Pattern pattern = Pattern.compile(REGEX);

        while (true) {
            String input = sc.nextLine();
            Matcher matcher = pattern.matcher(input);

            if (matcher.find()) {
                String racerName = matcher.group("name");
                int length = Integer.parseInt(matcher.group("length"));
                String code = matcher.group("code");

                if (code.length() == length) {
                    StringBuilder decrypted = new StringBuilder();
                    for (int i = 0; i < code.length(); i++) {
                        decrypted.append((char)(code.charAt(i) + length));
                    }

                    System.out.printf("Coordinates found! %s -> %s", racerName, decrypted);
                    return;
                } else {
                    System.out.println("Nothing found!");
                }
            } else {
                System.out.println("Nothing found!");
            }
        }
    }
}
