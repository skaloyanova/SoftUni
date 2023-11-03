package c_MultidimensionalArrays_Lab;

import java.util.*;

public class FindTheRealQueen {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        final int SIZE = 8;
        String[][] matrix = new String[SIZE][SIZE];

        for (int i = 0; i < matrix.length; i++) {
            matrix[i] = sc.nextLine().split("\\s+");
        }

        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                if ("q".equals(matrix[row][col]) && isValidQ(matrix, row, col)) {
                    System.out.println(row + " " + col);
                }
            }
        }
    }

    private static boolean isValidQ(String[][] matrix, int row, int col) {
        for (int i = -1; i <= 1 ; i++) {
            for (int j = -1; j <= 1; j++) {
                int currentRow = row;
                int currentCol = col;

                if (i == 0 && j == 0) {
                    continue;
                }

                currentRow = currentRow + i;
                currentCol = currentCol + j;

                while(isValidPosition(matrix, currentRow, currentCol)) {
                    if ("q".equals(matrix[currentRow][currentCol])) {
                        return false;
                    }
                    currentRow = currentRow + i;
                    currentCol = currentCol + j;
                }
            }
        }
        return true;
    }

    private static boolean isValidPosition(String[][] matrix, int currentRow, int currentCol) {
        return currentRow >= 0 && currentRow < matrix.length &&
                currentCol >= 0 && currentCol < matrix[currentRow].length;
    }
}
