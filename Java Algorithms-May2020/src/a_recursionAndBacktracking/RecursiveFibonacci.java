package a_recursionAndBacktracking;

import java.util.Scanner;

public class RecursiveFibonacci {
    static long[] fibSum;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        fibSum = new long[n + 1];

        long fibonacci = fibonacci(n);
        System.out.println(fibonacci);
    }

    private static long fibonacci(int n) {
        if (n == 0 || n == 1) {
            return 1;
        }

        if (fibSum[n] != 0) {
            return fibSum[n];
        }

        fibSum[n] = fibonacci(n - 2) + fibonacci(n - 1);

        return fibSum[n];
    }
}