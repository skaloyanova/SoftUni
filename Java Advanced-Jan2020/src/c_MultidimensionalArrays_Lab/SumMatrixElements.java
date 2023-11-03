package c_MultidimensionalArrays_Lab;

import java.util.Scanner;

public class SumMatrixElements {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] rowCols = sc.nextLine().split(", ");
        int rows = Integer.parseInt(rowCols[0]);
        int cols = Integer.parseInt(rowCols[1]);
        int[][] matrix = new int[rows][cols];

        System.out.println(matrix.length);
        System.out.println(matrix[0].length);

        int sum = 0;
        //Var1
//        for (int i = 0; i < rows; i++) {
//            sum += Arrays.stream(sc.nextLine().split(", ")).mapToInt(Integer::parseInt).sum();
//        }

        //Var2
        for (int i = 0; i < rows; i++) {
            String[] line = sc.nextLine().split(", ");
            for (int j = 0; j < cols; j++) {
                matrix[i][j] = Integer.parseInt(line[j]);
            }
        }
        for (int[] ints : matrix) {
            for (int anInt : ints) {
                sum += anInt;
            }
        }
        System.out.println(sum);
    }
}
