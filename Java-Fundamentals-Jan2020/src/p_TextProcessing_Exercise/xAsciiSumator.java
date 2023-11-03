package p_TextProcessing_Exercise;

import java.util.Scanner;

public class xAsciiSumator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int start = sc.nextLine().charAt(0);
        int end = sc.nextLine().charAt(0);
        String text = sc.nextLine();

        int min = Math.min(start, end);
        int max = Math.max(start, end);
        int sum = 0;

        for (int i = 0; i < text.length(); i++) {
            if (text.charAt(i) > min && text.charAt(i) < max) {
                sum += text.charAt(i);
            }
        }
        System.out.println(sum);
    }
}
