package g_Methods_Lab;

import java.text.DecimalFormat;
import java.util.Scanner;

public class MathOperations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num1 = Integer.parseInt(sc.nextLine());
        char operator = sc.nextLine().charAt(0);
        int num2 = Integer.parseInt(sc.nextLine());
        DecimalFormat df = new DecimalFormat("#.##");

        double result = calculate(num1, num2, operator);
        System.out.println(df.format(result));
    }

    private static double calculate(int num1, int num2, char operator) {
        double result = 0;
        switch (operator) {
            case '+': result = num1 + num2; break;
            case '-': result = num1 - num2; break;
            case '*': result = num1 * num2; break;
            case '/': result = num1 * 1.0 / num2; break;
        }
        return result;
    }
}
