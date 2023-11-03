package f_Arrays_Exercise;

import java.util.Scanner;

public class xRecursiveFibonacci {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        System.out.println(GetFibonacci(n));
    }

    private static long GetFibonacci(int n) {
       if (n == 0 || n == 1) {
           return n;
       } else {
           return GetFibonacci(n - 1) + GetFibonacci(n - 2);
       }
    }
}
