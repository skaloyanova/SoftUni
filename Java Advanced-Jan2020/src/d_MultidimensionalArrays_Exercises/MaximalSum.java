package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class MaximalSum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();
        int[][] matrix = new int[rows][cols];

        //read matrix
        for (int i = 0; i < matrix.length; i++) {
            matrix[i] = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        }

        if (rows < 3 || cols < 3) {
            return;
        }
        int maxSum = Integer.MIN_VALUE;
        int rowMaxSum = 1;
        int colMaxSum = 1;

        for (int row = 1; row < matrix.length - 1; row++) {
            for (int col = 1; col < matrix[row].length - 1; col++) {
                int sum = sumSquare(matrix, row, col);
                if (sum > maxSum) {
                    maxSum = sum;
                    rowMaxSum = row;
                    colMaxSum = col;
                }
            }
        }
        System.out.println("Sum = " + maxSum);
        printMatrixWithMaxSum(matrix, rowMaxSum, colMaxSum);
    }

    private static int sumSquare(int[][] matrix, int row, int col) {
        int sum = 0;

        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                int currentRow = row + i;
                int currentCol = col + j;
                sum += matrix[currentRow][currentCol];
            }
        }
        return sum;
    }

    private static void printMatrixWithMaxSum(int[][] matrix, int rowMaxSum, int colMaxSum) {
        for (int i = rowMaxSum - 1; i <= rowMaxSum + 1; i++) {
            for (int j = colMaxSum - 1; j <= colMaxSum + 1; j++) {
                System.out.print(matrix[i][j] + " ");
            }
            System.out.println();
        }
    }
}
