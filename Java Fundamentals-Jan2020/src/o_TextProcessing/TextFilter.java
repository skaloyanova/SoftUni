package o_TextProcessing;

import java.util.Scanner;

public class TextFilter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] banWords = sc.nextLine().split(", ");
        String text = sc.nextLine();

        for (String word : banWords) {
            StringBuilder replacement = new StringBuilder();
            for (int j = 0; j < word.length(); j++) {
                replacement.append("*");
            }
            text = text.replace(word, replacement);
        }

        System.out.println(text);
    }
}
