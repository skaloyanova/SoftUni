package c_MultidimensionalArrays_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class CompareMatrices {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[][] matrix1 = readMatrix(sc);
        int[][] matrix2 = readMatrix(sc);

        String isEqual = "equal";

        if (matrix1.length != matrix2.length || matrix1[0].length != matrix2[0].length) {
            System.out.println("not equal");
            return;
        }

        //var1
        for (int i = 0; i < matrix1.length; i++) {
            if (Arrays.toString(matrix1[i]).compareTo(Arrays.toString(matrix2[i])) != 0) {
                isEqual = "not equal";
                break;
            }
        }
        //var2
//        for (int row = 0; row < matrix1.length; row++) {
//            for (int col = 0; col < matrix1[row].length; col++) {
//                if (matrix1[row][col] != matrix2[row][col]) {
//                    isEqual = "not equal";
//                    break;
//                }
//            }
//        }

        System.out.println(isEqual);
    }

    private static int[][] readMatrix(Scanner sc) {
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        int[][] matrix = new int[rows][cols];

        for (int i = 0; i < rows; i++) {
            String[] line = sc.nextLine().split("\\s+");
            for (int j = 0; j < cols; j++) {
                matrix[i][j] = Integer.parseInt(line[j]);
            }
        }
        return matrix;
    }
}