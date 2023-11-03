package Final2019_12_07_gr2;

import java.util.Scanner;

public class NikuldenCharity {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        String command = sc.nextLine();

        while (!"Finish".equals(command)) {
            String[] tokens = command.split("\\s+");

            switch (tokens[0]) {
                case "Replace":
                    String currentChar = tokens[1];
                    String newChar = tokens[2];
                    text = text.replace(currentChar, newChar);
                    System.out.println(text);
                    break;

                case "Cut":
                    int startIndex = Integer.parseInt(tokens[1]);
                    int endIndex = Integer.parseInt(tokens[2]);
                    if (isNotValidIndex(text, startIndex) || isNotValidIndex(text, endIndex)) {
                        System.out.println("Invalid indexes!");
                        break;
                    }
                    String result = text.substring(0,startIndex);
                    if (endIndex < text.length() - 1) {
                        result += text.substring(endIndex + 1);
                    }
                    text = result;
                    System.out.println(text);
                    break;

                case "Make":
                    String upLow = tokens[1];
                    if ("Upper".equals(upLow)) {
                        text = text.toUpperCase();
                    }
                    if ("Lower".equals(upLow)) {
                        text = text.toLowerCase();
                    }
                    System.out.println(text);
                    break;

                case "Check":
                    String pattern = tokens[1];
                        if (text.contains(pattern)) {
                            System.out.println("Message contains " + pattern);
                        } else {
                            System.out.println("Message doesn't contain " + pattern);
                        }
                    break;

                case "Sum":
                    int startIndexSum = Integer.parseInt(tokens[1]);
                    int endIndexSum = Integer.parseInt(tokens[2]);
                    if (isNotValidIndex(text, startIndexSum) || isNotValidIndex(text, endIndexSum)) {
                        System.out.println("Invalid indexes!");
                        break;
                    }

                    String sub = text.substring(startIndexSum, endIndexSum + 1);
                    int sum = 0;
                    for (int i = 0; i < sub.length(); i++) {
                        sum += sub.charAt(i);
                    }
                    System.out.println(sum);
                    break;
            }

            command = sc.nextLine();
        }
    }
    private static boolean isNotValidIndex(String text, int index) {
        return index < 0 || index >= text.length();
    }
}
