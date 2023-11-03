package Final2020_04_04_gr1;

import java.util.Scanner;

public class ActivationKeys {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        int length = text.length();

        String input = sc.nextLine();
        while (!"Generate".equals(input)) {
            String[] tokens = input.split(">>>");
            String command = tokens[0];

            switch (command) {
                case "Contains":
                    String subString = tokens[1];
                    if (text.contains(subString)) {
                        System.out.println(text + " contains " + subString);
                    } else {
                        System.out.println("Substring not found!");
                    }
                    break;
                case "Flip":
                    String lowUp = tokens[1];
                    int startIndexF = Integer.parseInt(tokens[2]);
                    int endIndexF = Integer.parseInt(tokens[3]);
                    if (isNonValidStartIndex(startIndexF, length) || isNonValidEndIndex(endIndexF, length)) {
                        break;
                    }
                    String first = text.substring(0, startIndexF);
                    String sub = text.substring(startIndexF, endIndexF);
                    String last = text.substring(endIndexF);

                    if (lowUp.equals("Upper")) {
                        sub = sub.toUpperCase();
                    } else if (lowUp.equals("Lower")) {
                        sub = sub.toLowerCase();
                    }

                    text = first + sub + last;
                    System.out.println(text);
                    break;
                case "Slice":
                    int startIndexS = Integer.parseInt(tokens[1]);
                    int endIndexS = Integer.parseInt(tokens[2]);
                    if (isNonValidStartIndex(startIndexS, length) || isNonValidEndIndex(endIndexS, length)) {
                        break;
                    }
                    String start = text.substring(0, startIndexS);
                    String end = text.substring(endIndexS);
                    text = start + end;
                    System.out.println(text);
                    break;
            }
            input = sc.nextLine();
        }
        System.out.println("Your activation key is: " + text);
    }

    private static boolean isNonValidStartIndex(int index, int length) {
        return index < 0 || index >= length;
    }

    private static boolean isNonValidEndIndex(int index, int length) {
        return index < 0 || index > length;
    }
}
