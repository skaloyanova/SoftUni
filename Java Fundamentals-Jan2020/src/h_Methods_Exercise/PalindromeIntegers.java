package h_Methods_Exercise;

import java.util.Scanner;

public class PalindromeIntegers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = "";

        while (true) {
            input = sc.nextLine();
            if (input.equalsIgnoreCase("end")) {
                break;
            }
            int number = Integer.parseInt(input);
            System.out.println(isPalindrome(number));
        }

    }

    private static boolean isPalindrome(int number) {
        char[] digits = String.valueOf(number).toCharArray();
        int firstIndex = 0;
        int lastIndex = digits.length - 1;

        for (int i = firstIndex; i <= lastIndex / 2; i++) {
            if (digits[i] != digits[lastIndex-i]) {
                return false;
            }
        }
        return true;
    }
}
