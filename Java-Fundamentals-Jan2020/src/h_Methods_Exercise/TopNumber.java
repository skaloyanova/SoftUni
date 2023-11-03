package h_Methods_Exercise;

import java.util.Scanner;

public class TopNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        printTopNumbers(n);
    }

    public static void printTopNumbers(int n) {

        for (int i = 1; i <= n; i++) {
            if (sumDigits(i) % 8 == 0 && hasOddDigit(i)) {
                System.out.println(i);
            }
        }
    }

    public static int sumDigits(int number) {
        number = Math.abs(number);
        int sum = 0;

        while (number > 0) {
            sum += number % 10;
            number = number / 10;
        }
        return sum;
    }

    public static boolean hasOddDigit(int number) {
        number = Math.abs(number);

        while (number > 0) {
            int lastDigit = number % 10;

            if (lastDigit % 2 != 0) {
                return true;
            }
            number = number / 10;
        }
        return false;
    }
}
