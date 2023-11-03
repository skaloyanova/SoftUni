package z_Exam_20191026;

import java.util.Scanner;

public class BookWorm {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        StringBuilder text = new StringBuilder(sc.nextLine());

        int size = Integer.parseInt(sc.nextLine());

        String[][] book = new String[size][size];

        // Player's coordinates
        int row = -1;
        int col = -1;

        for (int i = 0; i < size; i++) {
            book[i] = sc.nextLine().split("");
            for (int j = 0; j < book[i].length; j++) {
                if (book[i][j].equals("P")) {
                    row = i;
                    col = j;
                }
            }
        }

        String command = sc.nextLine();
        while (!"end".equals(command)) {
            int newRow = row;
            int newCol = col;

            switch (command) {
                case "up": newRow--; break;
                case "down": newRow++; break;
                case "right": newCol++; break;
                case "left": newCol--; break;
            }

            if (isValidPosition(newRow, newCol, book)) {
                if (!book[newRow][newCol].equals("-")) {
                    text.append(book[newRow][newCol]);
                }
                book[newRow][newCol] = "P";
                book[row][col] = "-";
                row = newRow;
                col = newCol;
            } else if (text.length() > 0){
                text.deleteCharAt(text.length() - 1);
            }

            command = sc.nextLine();
        }

        // print
        System.out.println(text);

        for (String[] bookRow : book) {
            System.out.println(String.join("", bookRow));
        }
    }

    private static boolean isValidPosition(int row, int col, String[][]matrix) {
        return row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length;
    }
}
