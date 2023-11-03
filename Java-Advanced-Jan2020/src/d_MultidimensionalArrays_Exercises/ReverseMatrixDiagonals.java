package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class ReverseMatrixDiagonals {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int row = sc.nextInt();
        int col = sc.nextInt();
        sc.nextLine();

        int[][] matrix = new int[row][col];

        for (int i = 0; i < matrix.length; i++) {
            matrix[i] = Arrays.stream(sc.nextLine().split("\\s+"))
                    .mapToInt(Integer::parseInt).toArray();
        }

        printRightAndMidDiagonals(matrix);
        printLeftDiagonals(matrix);
    }

    private static void printLeftDiagonals(int[][] matrix) {
        int lastRow = matrix.length - 2;
        int lastCol = matrix[0].length - 1;
        for (int row = lastRow; row >= 0; row--) {
            int currentRowIndex = row;
            int currentColIndex = 0;
            while (currentColIndex <= lastCol && currentRowIndex >= 0) {
                System.out.print(matrix[currentRowIndex][currentColIndex] + " ");
                currentRowIndex--;
                currentColIndex++;
            }
            System.out.println();
        }
    }

    private static void printRightAndMidDiagonals(int[][] matrix) {
        int lastRow = matrix.length - 1;
        int lastCol = matrix[0].length - 1;
        for (int col = lastCol; col >= 0; col--) {
            int currentRowIndex = lastRow;
            int currentColIndex = col;
            while (currentColIndex <= lastCol && currentRowIndex >= 0) {
                System.out.print(matrix[currentRowIndex][currentColIndex] + " ");
                currentRowIndex--;
                currentColIndex++;
            }
            System.out.println();
        }
    }
}
