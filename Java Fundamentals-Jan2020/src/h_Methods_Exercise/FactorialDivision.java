package h_Methods_Exercise;

import java.util.Scanner;

public class FactorialDivision {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double n1 = Double.parseDouble(sc.nextLine());
        double n2 = Double.parseDouble(sc.nextLine());

        double result = getFactorial(n1) * 1.0 / getFactorial(n2);
        System.out.println(String.format("%.2f", result));
    }

    public static double getFactorial(double n) {
//        if (n == 0) {
//            return 1;
//        }
//        return n * getFactorial(n-1);

        double result = 1;
        for (int i = 1; i <= n; i++) {
            result *= i;
        }
        return result;
    }

}
