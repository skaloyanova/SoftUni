package a_workingWithAbstraction_Lab;

import java.util.Scanner;

public class RhombusOfStars {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        for (int i = 1; i <= n; i++) {
            printRow(n, i);
        }
        for (int i = n - 1; i >= 1; i--) {
            printRow(n, i);
        }
    }

    private static void printRow(int totalStars, int starsToPrint) {
            printPattern(totalStars - starsToPrint, " ");
            printPattern(starsToPrint, "* ");
            System.out.println();
    }

    private static void printPattern(int count, String symbol) {
        for (int i = 0; i < count; i++) {
            System.out.print(symbol);
        }
    }
}
