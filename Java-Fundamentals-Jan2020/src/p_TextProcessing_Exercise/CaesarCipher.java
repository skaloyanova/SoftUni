package p_TextProcessing_Exercise;

import java.util.Scanner;

public class CaesarCipher {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.length(); i++) {
            char newChar = (char) (input.charAt(i) + 3);
            result.append(newChar);
        }
        System.out.println(result);
    }
}
