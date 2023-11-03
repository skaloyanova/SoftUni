package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class xSortNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num1 = Integer.parseInt(sc.nextLine());
        int num2 = Integer.parseInt(sc.nextLine());
        int num3 = Integer.parseInt(sc.nextLine());

        int max = Math.max(Math.max(num1, num2), num3);
        int min = Math.min(Math.min(num1, num2), num3);
        int middle = (num1 + num2 + num3) - (max + min);

        System.out.println(max);
        System.out.println(middle);
        System.out.println(min);
    }
}
