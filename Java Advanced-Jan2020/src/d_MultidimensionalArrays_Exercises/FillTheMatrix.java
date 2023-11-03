package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class FillTheMatrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split(", ");
        int size = Integer.parseInt(input[0]);
        String pattern = input[1];

        int[][] matrix = new int[size][size];
        if ("A".equals(pattern)) {
            matrix = fillMatrixA(size);
        } else if ("B".equals(pattern)) {
            matrix = fillMatrixB(size);
        }

        printMatrix(matrix);
    }

    private static int[][] fillMatrixB(int size) {
        int[][] matrix = new int[size][size];
        int num = 1;
        for (int col = 0; col < size; col++) {
            for (int row = 0; row < size; row++) {
                if (col % 2 == 0) {
                    matrix[row][col] = num++;
                } else {
                    matrix[size - 1 - row][col] = num++;
                }
            }
        }
        return matrix;
    }

    private static int[][] fillMatrixA(int size) {
        int[][] matrix = new int[size][size];
        int num = 1;
        for (int col = 0; col < size; col++) {
            for (int row = 0; row < size; row++) {
                matrix[row][col] = num++;
            }
        }
        return matrix;
    }

    private static void printMatrix(int[][] matrix) {
        for (int[] ints : matrix) {
            System.out.println(Arrays.toString(ints).replaceAll("[\\[\\],]", ""));
        }
    }
}
