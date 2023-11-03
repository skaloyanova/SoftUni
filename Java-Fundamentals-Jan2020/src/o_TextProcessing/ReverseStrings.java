package o_TextProcessing;

import java.util.Scanner;

public class ReverseStrings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String text = sc.nextLine();

        while (!"end".equals(text)) {
            String reverse = "";
            for (int i = text.length() - 1; i >= 0; i--) {
                reverse += text.charAt(i);
            }
            System.out.println(String.format("%s = %s", text, reverse));
            text = sc.nextLine();
        }
    }
}
