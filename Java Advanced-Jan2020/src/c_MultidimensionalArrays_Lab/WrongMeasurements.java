package c_MultidimensionalArrays_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class WrongMeasurements {
    private static int wrongNum;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = Integer.parseInt(sc.nextLine());
        int[][] matrix = new int[rows][];
        for (int i = 0; i < rows; i++) {
            matrix[i] = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        }
        int wrongRow = sc.nextInt();
        int wrongCol = sc.nextInt();

        wrongNum = matrix[wrongRow][wrongCol];

        int[][] result = new int[matrix.length][];
        for (int i = 0; i < matrix.length; i++) {
            result[i] = Arrays.copyOf(matrix[i],matrix[i].length);
        }

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                int current = matrix[row][col];
                if (current == wrongNum) {
                    int up = getNumber(matrix,row - 1, col);
                    int down = getNumber(matrix,row + 1, col);
                    int left = getNumber(matrix, row,col - 1);
                    int right = getNumber(matrix, row, col + 1);
                    result[row][col] = up + down + left + right;
                } else {
                    result[row][col] = current;
                }
            }
        }
        //print
        for (int i = 0; i < rows; i++) {
            System.out.println(Arrays.toString(result[i]).replaceAll("[\\[\\],]", ""));
        }
    }

    private static int getNumber(int[][] matrix, int row, int col) {
        if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[row].length) {
            return 0;
        }
        int number = matrix[row][col];
        return number == wrongNum ? 0 : number;
    }
}
