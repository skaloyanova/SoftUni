package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class SumOfOddNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        int n = Integer.parseInt(sc.nextLine());
        int sum = 0;

        for (int i = 1; i <= 2*n; i+=2) {
            System.out.println(i);
            sum += i;
        }
        System.out.printf("Sum: %d", sum);
    }
}
