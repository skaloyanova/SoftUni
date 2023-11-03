package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class PrintAndSum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int from = Integer.parseInt(sc.nextLine());
        int to = Integer.parseInt(sc.nextLine());

        int sum = 0;

        for (int i = from; i <= to; i++) {
            System.out.print(i + " ");
            sum = sum + i;
        }
        System.out.printf("%nSum: %d", sum);
    }
}
