package c_MultidimensionalArrays_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class MaximumSumOf2x2Submatrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] dimensions = sc.nextLine().split(", ");
        int rows = Integer.parseInt(dimensions[0]);
        int cols = Integer.parseInt(dimensions[1]);

        int[][] matrix = new int[rows][cols];
        for (int i = 0; i < rows; i++) {
            matrix[i] = Arrays.stream(sc.nextLine().split(", ")).mapToInt(Integer::parseInt).toArray();
        }

        int maxSum = Integer.MIN_VALUE;
        String outputLine1 = "";
        String outputLine2 = "";
        for (int row = 0; row < rows - 1; row++) {
            for (int col = 0; col < cols - 1; col++) {
                int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                if (sum > maxSum) {
                    maxSum = sum;
                    outputLine1 = "" + matrix[row][col] + " " + matrix[row][col + 1];
                    outputLine2 = "" + matrix[row + 1][col] + " " + matrix[row + 1][col + 1];
                }
            }
        }
        System.out.println(outputLine1);
        System.out.println(outputLine2);
        System.out.println(maxSum);
    }
}
