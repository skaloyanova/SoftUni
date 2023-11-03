package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Scanner;

public class RecursiveFibonacci {
    private static long[] fibSave;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
         int n = Integer.parseInt(sc.nextLine());

         //VARIANT #1
//        ArrayDeque<Long> queue = new ArrayDeque<>();
//        queue.offer(1L);
//        queue.offer(1L);
//
//        long result = 0;
//        for (int i = 2; i <= n; i++) {
//            result = queue.poll() + queue.peek();
//            queue.offer(result);
//        }
//        if (n == 1) {
//            System.out.println(1);
//        } else {
//            System.out.println(result);
//        }

        //VARIANT #2
        fibSave = new long[n + 1];

        long result = fibonacci(n);
        System.out.println(result);
    }

    private static long fibonacci(int n) {
        if (n <= 1) {
            return 1;
        }

        if (fibSave[n] != 0) {
            return fibSave[n];
        }

        fibSave[n] = fibonacci(n - 2) + fibonacci(n - 1);

        return fibSave[n];
    }
}
