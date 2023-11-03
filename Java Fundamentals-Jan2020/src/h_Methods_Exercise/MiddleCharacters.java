package h_Methods_Exercise;

import java.util.Scanner;

public class MiddleCharacters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();

        middleCharOfString(input);
    }

    public static void middleCharOfString(String text) {
        int length = text.length();
        int midIndex = (length - 1) / 2;

        System.out.print(text.charAt(midIndex));

        if (length % 2 == 0) {
            System.out.println(text.charAt(midIndex + 1));
        }
    }
}
