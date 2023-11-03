package g_Methods_Lab;

import java.util.Scanner;

public class PrintingTriangle {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        printTop(n);
        printBottom(n-1);
    }

    public static void printTop(int rows) {
        for (int i = 1; i <= rows; i++) {
            printRow(i);
        }
    }

    public static void printBottom(int rows) {
        for (int i = rows; i >= 1; i--) {
            printRow(i);
        }
    }

    private static void printRow(int i) {
        for (int j = 1; j <= i; j++) {
            System.out.print(j + " ");
        }
        System.out.println();
    }

}
