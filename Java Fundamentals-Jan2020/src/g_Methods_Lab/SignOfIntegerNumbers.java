package g_Methods_Lab;

import java.util.Scanner;

public class SignOfIntegerNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        printSign(n);
    }

    private static void printSign(int n) {
        String sign = "";
        if (n > 0) {
            sign = "positive";
        } else if (n == 0) {
            sign = "zero";
        } else {
            sign = "negative";
        }
        System.out.printf("The number %d is %s.", n, sign);
    }

}
