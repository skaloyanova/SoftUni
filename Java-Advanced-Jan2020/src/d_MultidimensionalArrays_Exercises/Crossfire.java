package d_MultidimensionalArrays_Exercises;

import java.util.ArrayList;
import java.util.Scanner;

public class Crossfire {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        ArrayList<ArrayList<Integer>> matrix = createMatrix(rows, cols);

        String input = sc.nextLine();

        while (!"Nuke it from orbit".equalsIgnoreCase(input)) {
            String[] tokens = input.split("\\s+");
            int row = Integer.parseInt(tokens[0]);
            int col = Integer.parseInt(tokens[1]);
            int radius = Integer.parseInt(tokens[2]);

//            if (row >= 0 && row < matrix.size() && col >= 0) {
//                if (col < matrix.get(row).size()) {
            destroyedSells(matrix, row, col, radius);
//                }
//            }
            matrix.removeIf(ArrayList::isEmpty);
            input = sc.nextLine();
        }
        printMatrix(matrix);
    }

    private static void destroyedSells(ArrayList<ArrayList<Integer>> matrix, int row, int col, int radius) {
        //vertical
        for (int i = row - radius; i <= row + radius; i++) {
            if (i == row) {     // this one will be removed in horizontal task
                continue;
            }
            if (i >= 0 && i < matrix.size() && col >= 0 && col < matrix.get(i).size()) {
                matrix.get(i).remove(col);
            }
        }

        //horizontal
        for (int i = col + radius; i >= col - radius; i--) {
            if (row >= 0 && row < matrix.size() && i >= 0 && i < matrix.get(row).size()) {
                matrix.get(row).remove(i);
            }
        }
    }

    private static void printMatrix(ArrayList<ArrayList<Integer>> matrix) {
        matrix.forEach(e -> {
            e.forEach(i -> System.out.print(i + " "));
            System.out.println();
        });
    }

    private static ArrayList<ArrayList<Integer>> createMatrix(int rows, int cols) {
        ArrayList<ArrayList<Integer>> matrix = new ArrayList<>();
        for (int i = 0; i < rows; i++) {
            ArrayList<Integer> row = new ArrayList<>();
            for (int j = 0; j < cols; j++) {
                int currentValue = i * cols + 1 + j;
                row.add(currentValue);
            }
            matrix.add(row);
        }
        return matrix;
    }
}
