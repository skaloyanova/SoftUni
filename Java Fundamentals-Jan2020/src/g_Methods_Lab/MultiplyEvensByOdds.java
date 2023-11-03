package g_Methods_Lab;

import java.util.Scanner;

public class MultiplyEvensByOdds {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num = Integer.parseInt(sc.nextLine());

        System.out.println(multiplyEvenWithOddSums(num));
    }

    private static int multiplyEvenWithOddSums(int number) {
        return sumEvenDigits(number) * sumOddDigits(number);
    }

    private static int sumEvenDigits(int number) {
        number = Math.abs(number); // 12345
        int lastDigit;
        int sumEvens = 0;

        while (number > 0) {
                lastDigit = number % 10;
            if (lastDigit % 2 == 0) {
                sumEvens += lastDigit;
            }
            number = number / 10;
        }
        return sumEvens;
    }

    private static int sumOddDigits(int number) {
        number = Math.abs(number);
        int lastDigit;
        int sumOdds = 0;

        while (number > 0) {
            lastDigit = number % 10;
            if (lastDigit % 2 != 0) {
                sumOdds += lastDigit;
            }
            number = number / 10;
        }
        return sumOdds;
    }
}
