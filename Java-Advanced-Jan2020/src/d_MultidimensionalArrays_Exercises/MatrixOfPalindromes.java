package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class MatrixOfPalindromes {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt(); sc.nextLine();
        String[][] matrix =  new String[rows][cols];

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                int firstChar = 'a' + row;
                int midChar = 'a' + row + col;
                String element = String.format("%c%c%c", firstChar, midChar, firstChar);
                matrix[row][col] = element;
            }
        }
        Arrays.stream(matrix).forEach(e -> System.out.println(Arrays.toString(e)
                .replaceAll("[\\[\\],]", "")));
    }
}
