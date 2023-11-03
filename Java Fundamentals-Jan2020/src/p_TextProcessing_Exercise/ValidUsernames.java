package p_TextProcessing_Exercise;

import java.util.Scanner;

public class ValidUsernames {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(", ");

        for (String word : input) {
            int length = word.length();
            if (length >= 3 && length <= 16 && containsCorrectChars(word)) {
                System.out.println(word);
            }
        }
    }

    private static boolean containsCorrectChars(String word) {
        int count = 0;
        for (int i = 0; i < word.length(); i++) {
            char current = word.charAt(i);
            if (Character.isLetterOrDigit(current) || current == '-' || current == '_') {
                count++;
            }
        }
        return count == word.length();
    }
}
