package p_TextProcessing_Exercise;

import java.util.Scanner;

public class MultiplyBigNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        StringBuilder result = new StringBuilder();

        String num1Str = sc.nextLine();

        while (num1Str.charAt(0) == '0') {
            num1Str = num1Str.substring(1);
        }

        int num2 = Integer.parseInt(sc.nextLine());
        int addition = 0;

        if (num2 < 0 || num2 > 9) {
            return;
        } else if (num2 == 0) {
            System.out.println(0);
            return;
        } else if (num2 == 1) {
            System.out.println(num1Str);
        } else {

            for (int i = num1Str.length() - 1; i >= 0; i--) {
                int digit = num1Str.charAt(i) - 48;
                int multiply = digit * num2 + addition;
                result.append(multiply % 10);
                addition = multiply / 10;
            }
        }

        if (addition != 0) {
            result.append(addition);
        }

        System.out.println(result.reverse());
    }
}
