package Final2019_12_07_gr1;

import java.util.Scanner;

public class EmailValidator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        int length = text.length();

        String input = sc.nextLine();
        while (!"Complete".equals(input)) {
            String[] tokens = input.split(" ");
            String command = tokens[0];

            switch (command) {
                case "Make":
                    if ("Upper".equals(tokens[1])) {
                        text = text.toUpperCase();
                        System.out.println(text);
                    } else if ("Lower".equals(tokens[1])) {
                        text = text.toLowerCase();
                        System.out.println(text);
                    }
                    break;
                case "GetDomain":
                    int count = Integer.parseInt(tokens[1]);
                    if (count <= length) {
                        System.out.println(text.substring(length - count));
                    }
                    break;
                case "GetUsername":
                    int index = text.indexOf("@");
                    if (index == -1) {
                        System.out.printf("The email %s doesn't contain the @ symbol.%n", text);
                    } else {
                        System.out.println(text.substring(0, index));
                    }
                    break;
                case "Replace":
                    char charToReplace = tokens[1].charAt(0);
                    text = text.replace(charToReplace, '-');
                    System.out.println(text);
                    break;
                case "Encrypt":
                    for (int i = 0; i < length; i++) {
                        System.out.print(0 + text.charAt(i) + " ");
                    }
                    System.out.println();
                    break;
            }


            input = sc.nextLine();
        }
    }
}
