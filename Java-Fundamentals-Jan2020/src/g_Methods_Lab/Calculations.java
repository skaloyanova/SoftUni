package g_Methods_Lab;

import java.util.Scanner;

public class Calculations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String operator = sc.nextLine();
        int num1 = Integer.parseInt(sc.nextLine());
        int num2 = Integer.parseInt(sc.nextLine());

        calculation(num1, num2, operator);

    }

    private static void calculation (int num1, int num2, String operator) {
        int result = 0;
        switch (operator) {
            case "add": result = sumNumbers(num1, num2); break;
            case "multiply": result = multiplyNumbers(num1, num2); break;
            case "subtract": result = subtractNumbers(num1, num2); break;
            case "divide": result = divideNumbers(num1, num2); break;
        }
        System.out.println(result);
    }

    private static int sumNumbers(int num1, int num2) {
        return num1 + num2;
    }

    private static int subtractNumbers(int num1, int num2) {
        return num1 - num2;
    }

    private static int multiplyNumbers(int num1, int num2) {
        return num1 * num2;
    }

    private static int divideNumbers(int num1, int num2) {
        return num1 / num2;
    }

}
