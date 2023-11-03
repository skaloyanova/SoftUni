package o_TextProcessing;

import java.util.Scanner;

public class DigitsLettersAndOther {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        StringBuilder letters = new StringBuilder();
        StringBuilder digits = new StringBuilder();
        StringBuilder symbols = new StringBuilder();

        for (int i = 0; i < text.length(); i++) {
            char currentChar = text.charAt(i);
            if (Character.isDigit(currentChar)) {
                digits.append(currentChar);
            } else if (Character.isLetter(currentChar)) {
                letters.append(currentChar);
            } else {
                symbols.append(currentChar);
            }
        }

        System.out.println(digits.toString());
        System.out.println(letters.toString());
        System.out.println(symbols.toString());
    }
}
