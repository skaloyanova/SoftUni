package c_MultidimensionalArrays_Lab;

import java.util.Scanner;

public class IntersectionOfTwoMatrices {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = Integer.parseInt(sc.nextLine());
        int cols = Integer.parseInt(sc.nextLine());

        String[][] matrix1 = new String[rows][cols];
        String[][] matrix2 = new String[rows][cols];

        for (int i = 0; i < rows; i++) {
            matrix1[i] = sc.nextLine().split("\\s+");
        }
        for (int i = 0; i < rows; i++) {
            matrix2[i] = sc.nextLine().split("\\s+");
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (matrix1[i][j].equals(matrix2[i][j])) {
                    System.out.print(matrix1[i][j] + " ");
                } else {
                    System.out.print("*" + " ");
                }
            }
            System.out.println();
        }
    }
}
