package p_TextProcessing_Exercise;

import java.util.Scanner;

public class StringExplosion {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        StringBuilder result = new StringBuilder();
        int strength = 0;

        for (int i = 0; i < text.length(); i++) {
            char current = text.charAt(i);

            if (current == '>') {
                result.append('>');
                strength += Integer.parseInt(String.valueOf(text.charAt(i + 1)));
            } else if (strength == 0) {
                result.append(current);
            } else {
                strength--;
            }
        }
        System.out.println(result);
    }
}
