package c_MultidimensionalArrays_Lab;

import java.util.Scanner;

public class PrintDiagonals {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int size = Integer.parseInt(sc.nextLine());
        String[][] matrix = new String[size][size];

        for (int i = 0; i < size; i++) {
            matrix[i] = sc.nextLine().split("\\s+");
        }
        int row = 0;
        int col = 0;
        String diagonal1 = "";
        String diagonal2 = "";
        while (row < size && col < size) {
            diagonal1 += matrix[row][col] + " ";
            diagonal2 += matrix[size - 1 - row][col] + " ";
            row++;
            col++;
        }
        System.out.println(diagonal1);
        System.out.println(diagonal2);
    }
}
