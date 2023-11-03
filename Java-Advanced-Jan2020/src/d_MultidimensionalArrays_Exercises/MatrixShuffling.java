package d_MultidimensionalArrays_Exercises;

import java.util.Scanner;

public class MatrixShuffling {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        String[][] matrix = new String[rows][cols];
        for (int i = 0; i < matrix.length; i++) {
            matrix[i] = sc.nextLine().split("\\s+");
        }

        String input = sc.nextLine();
        while (!"END".equals(input)) {
            String[]tokens = input.split("\\s+");

            String swap = tokens[0];
            if (!"swap".equals(swap) || tokens.length != 5) {
                System.out.println("Invalid input!");
            } else {

                int row1 = Integer.parseInt(tokens[1]);
                int col1 = Integer.parseInt(tokens[2]);
                int row2 = Integer.parseInt(tokens[3]);
                int col2 = Integer.parseInt(tokens[4]);

                try {
                    String temp = matrix[row1][col1];
                    matrix[row1][col1] = matrix[row2][col2];
                    matrix[row2][col2] = temp;
                    printMatrix(matrix);
                } catch (IndexOutOfBoundsException | IllegalStateException ex) {
                    System.out.println("Invalid input!");

                }
            }
            input = sc.nextLine();
        }
    }

    private static void printMatrix(String[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j] + " ");
            }
            System.out.println();
        }
    }
}
