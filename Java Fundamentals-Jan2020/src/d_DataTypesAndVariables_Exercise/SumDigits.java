package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class SumDigits {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int number = Integer.parseInt(sc.nextLine());

        int sum = 0;
        while (number > 0) {
            int currentDigit = number % 10;
            sum += currentDigit;

            number = number / 10;
        }
        System.out.println(sum);
    }
}
