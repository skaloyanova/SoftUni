package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class MultiplicationTable2 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int number = Integer.parseInt(sc.nextLine());
        int multiplier = Integer.parseInt(sc.nextLine());

        int result = 0;

        for (int i = multiplier; i <= 10; i++) {
            result = number * i;
            System.out.printf("%d X %d = %d%n", number, i, result);
        }

        if (result == 0) {
            System.out.printf("%d X %d = %d", number, multiplier, Math.multiplyExact(number, multiplier));
        }
    }
}
