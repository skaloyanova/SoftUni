package d_MultidimensionalArrays_Exercises;

import java.util.ArrayDeque;
import java.util.Scanner;

public class TheMatrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        char[][] matrix = new char[rows][cols];

        //read the matrix
        for (int i = 0; i < matrix.length; i++) {
            String[] temp = sc.nextLine().split("\\s+");
            for (int j = 0; j < matrix[i].length; j++) {
                matrix[i][j] = temp[j].charAt(0);
            }
        }

        char replacementChar = sc.nextLine().charAt(0);
        int startRow = sc.nextInt();
        int startCol = sc.nextInt();

        char charToReplace = matrix[startRow][startCol];

        //var1
//        replaceRecursive(matrix, startRow, startCol, charToReplace, replacementChar);

        //var2
        ArrayDeque<int[]> queue = new ArrayDeque<>();
        matrix[startRow][startCol] = replacementChar;
        queue.offer(new int[] {startRow, startCol});
        while (queue.size() > 0) {
            int[]tmp = queue.poll();
            int row = tmp[0];
            int col = tmp[1];

            checkDirections(queue, matrix, row - 1, col, charToReplace, replacementChar);
            checkDirections(queue, matrix, row + 1, col, charToReplace, replacementChar);
            checkDirections(queue, matrix, row, col - 1, charToReplace, replacementChar);
            checkDirections(queue, matrix, row, col + 1, charToReplace, replacementChar);
        }

        //print
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                System.out.print(matrix[i][j]);
            }
            System.out.println();
        }
    }

    private static void checkDirections(ArrayDeque<int[]> queue, char[][] matrix, int row, int col,
                                        char charToReplace, char replacementChar) {
        if (isNotValidIndex(row, matrix.length) || isNotValidIndex(col, matrix[row].length)) {
            return;
        }

        if (matrix[row][col] == charToReplace) {
            matrix[row][col] = replacementChar;
            queue.offer(new int[] {row, col});
        }
    }

    private static boolean isNotValidIndex(int index, int size) {
        return index < 0 || index >= size;
    }

    private static void replaceRecursive(char[][] matrix, int row, int col, char charToReplace, char replacementChar) {
        if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[row].length) {
            return;
        }
        if (matrix[row][col] != charToReplace) {
            return;
        } else {
            matrix[row][col] = replacementChar;
        }
        replaceRecursive(matrix, row - 1, col, charToReplace, replacementChar);
        replaceRecursive(matrix, row + 1, col, charToReplace, replacementChar);
        replaceRecursive(matrix, row, col - 1, charToReplace, replacementChar);
        replaceRecursive(matrix, row, col + 1, charToReplace, replacementChar);
    }
}
