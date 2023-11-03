package a_recursionAndBacktracking;

import java.util.Scanner;

public class RecursiveDrawing {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        drawFigure(n);
    }

    private static void drawFigure(int n) {
        if (n == 0) {
            return;
        }
        printLine('*', n);

        drawFigure(n - 1);

        printLine('#', n);
    }

    private static void printLine(char symbol, int n) {
        for (int i = 0; i < n; i++) {
            System.out.print(symbol);
        }
        System.out.println();
    }

}

