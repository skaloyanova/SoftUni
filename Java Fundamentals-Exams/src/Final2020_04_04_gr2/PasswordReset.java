package Final2020_04_04_gr2;

import java.util.Scanner;

public class PasswordReset {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        String input = sc.nextLine();
        while (!"Done".equals(input)) {
            String[] tokens = input.split("\\s+");

            switch (tokens[0]) {
                case "TakeOdd":
                    StringBuilder newPass = new StringBuilder();
                    for (int i = 0; i < text.length(); i++) {
                        if (i % 2 != 0) {
                            newPass.append(text.charAt(i));
                        }
                    }
                    text = newPass.toString();
                    System.out.println(text);
                    break;
                case "Cut":
                    int index = Integer.parseInt(tokens[1]);
                    int length = Integer.parseInt(tokens[2]);
                    String toRemove = text.substring(index, index + length);
                    text = text.replaceFirst(toRemove, "");
                    System.out.println(text);
                    break;
                case "Substitute":
                    String subString = tokens[1];
                    String replacement = tokens[2];

                    if (text.contains(subString)) {
                        text = text.replaceAll(subString, replacement);
                        System.out.println(text);
                    } else {
                        System.out.println("Nothing to replace!");
                    }
                    break;
            }

            input = sc.nextLine();
        }
        System.out.println("Your password is: " + text);
    }
}
