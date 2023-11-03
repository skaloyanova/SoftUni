package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class DiagonalDifference {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int size = Integer.parseInt(sc.nextLine());
        int[][] matrix = new int[size][size];
        for (int i = 0; i < size; i++) {
            matrix[i] = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        }

        int row = size - 1; //row index for Secondary diagonal
        int col = 0;        //row and col index for Primary and col for Secondary diagonal
        int sumPrimary = 0;
        int sumSecondary = 0;

        while (col < size) {
            sumPrimary += matrix[col][col];
            sumSecondary += matrix[row][col];
            col++;
            row--;
        }

        int diff = Math.abs(sumPrimary - sumSecondary);
        System.out.println(diff);
    }
}
