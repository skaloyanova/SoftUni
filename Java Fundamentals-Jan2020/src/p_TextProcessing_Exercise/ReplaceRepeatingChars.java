package p_TextProcessing_Exercise;

import java.util.Scanner;

public class ReplaceRepeatingChars {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        StringBuilder sb = new StringBuilder(text);

        for (int i = 1; i < sb.length(); i++) {
            char current = sb.charAt(i - 1);
            char next = sb.charAt(i);
            if (current == next) {
                sb.deleteCharAt(i);
                i--;
            }
        }
        System.out.println(sb);
    }
}
