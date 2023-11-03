package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class xReverseString {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        // VARIANT 1
//      StringBuilder input = new StringBuilder(sc.nextLine());
//      StringBuilder reverse = input.reverse();
//
//      System.out.println(reverse);

        // VARIANT 2
        String input = sc.nextLine();

        String reverse = "";

        for (int i = input.length() - 1; i >= 0; i--) {
            reverse = reverse + input.charAt(i);
        }
        System.out.println(reverse);
    }
}
