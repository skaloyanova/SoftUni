package a_recursionAndBacktracking;

import java.util.Scanner;

public class RecursiveFactorial {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

//        // Iteration solution
//        long factorial = 1;
//        for (int i = n; i >= 1; i--) {
//            factorial *= i;
//        }
//        System.out.println("Iteration factorial: " + factorial);

        // Recursion solution
        System.out.println(factorial(n));
    }

    private static long factorial(int n) {
        if (n == 1) {
            return 1;
        }

        return n * factorial(n - 1);
    }
}

