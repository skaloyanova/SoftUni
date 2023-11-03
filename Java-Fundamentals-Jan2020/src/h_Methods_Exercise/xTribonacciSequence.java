package h_Methods_Exercise;

import java.util.Scanner;

public class xTribonacciSequence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        tribonacci(n);
    }

    public static void tribonacci(int n){
        int arraySize = 3;

        if (n > 3) {
            arraySize = n;
        }

        int[] tribonacci = new int[arraySize];
        tribonacci[0] = 1;
        tribonacci[1] = 1;
        tribonacci[2] = 2;

        for (int i = 3; i < tribonacci.length; i++) {
            tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
        }

        for (int i = 0; i < n; i++) {
            System.out.print(tribonacci[i] + " ");
        }
    }
}
