package h_Methods_Exercise;

import java.util.Scanner;

public class AddAndSubtract {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n1 = Integer.parseInt(sc.nextLine());
        int n2 = Integer.parseInt(sc.nextLine());
        int n3 = Integer.parseInt(sc.nextLine());

        System.out.println(sumSubtract(n1, n2, n3));
    }

    private static int sumSubtract(int num1, int num2, int num3) {
        return subtractNumbers(sumNumbers(num1, num2), num3);
    }

    private static int sumNumbers(int num1, int num2) {
        return num1 + num2;
    }

    private static int subtractNumbers(int num1, int num2) {
        return num1 - num2;
    }
}
