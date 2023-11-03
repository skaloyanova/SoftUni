package q_RegularExpressions_Lab_Exercise;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class xSantaSecretHelper {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int key = Integer.parseInt(sc.nextLine());

        String input = sc.nextLine();
        while (!"end".equals(input)) {
            StringBuilder message = new StringBuilder();

            for (int i = 0; i < input.length(); i++) {
                char newChar = (char)(input.charAt(i) - key);
                message.append(newChar);
            }

            String regex = "@(?<name>[A-Za-z]+)[^@\\-!:>]*!(?<type>[NG])!";
            Matcher match = Pattern.compile(regex).matcher(message);

            if (match.find()) {
                String name = match.group("name");
                if ("G".equals(match.group("type"))) {
                    System.out.println(name);
                }
            }

            input = sc.nextLine();
        }

    }
}
