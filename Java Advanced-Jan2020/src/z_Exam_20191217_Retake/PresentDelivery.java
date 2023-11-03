package z_Exam_20191217_Retake;

import java.util.Arrays;
import java.util.Scanner;

public class PresentDelivery {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int presentsCount = Integer.parseInt(sc.nextLine());
        int size = Integer.parseInt(sc.nextLine());

        char[][] neighbourhood = new char[size][size];

        // Santa's position
        int rowSanta = -1;
        int colSanta = -1;

        int totalNiceKidsCount = 0;

        // Read the matrix input
        for (int i = 0; i < size; i++) {
            String line = sc.nextLine().replaceAll("\\s+", "");
            neighbourhood[i] = line.toCharArray();
            if (line.contains("S")) {
                rowSanta = i;
                colSanta = line.indexOf('S');
            }

            totalNiceKidsCount += Arrays.stream(line.split("")).filter(x -> "V".equals(x)).count();
        }

        int niceKidsWithPresentsCount = 0;

        int newRow = rowSanta;
        int newCol = colSanta;

        String command = sc.nextLine();
        while (!"Christmas morning".equals(command)) {

            switch (command) {
                case "up": newRow--; break;
                case "down": newRow++; break;
                case "left": newCol--; break;
                case "right": newCol++; break;
            }

            if (!isValidPosition(newRow, newCol, neighbourhood)) {
                System.out.println("Santa ran out of presents.");
                break;
            }

            char newPositionValue = neighbourhood[newRow][newCol];
            neighbourhood[rowSanta][colSanta] = '-';
            rowSanta = newRow;
            colSanta = newCol;
            neighbourhood[rowSanta][colSanta] = 'S';

            switch (newPositionValue) {
                case 'V':
                    niceKidsWithPresentsCount++;
                    presentsCount--;
                    break;
                case 'C':
                    // left, right, upwards and downwards
                    char left = neighbourhood[newRow][newCol - 1];
                    char right = neighbourhood[newRow][newCol + 1];
                    char up = neighbourhood[newRow - 1][newCol];
                    char down = neighbourhood[newRow + 1][newCol];

                    if (left == 'V' || left == 'X') {
                        if (left == 'V') {
                            niceKidsWithPresentsCount++;
                        }
                        presentsCount--;
                        neighbourhood[newRow][newCol - 1] = '-';
                        if (presentsCount == 0) {break;}
                    }

                    if (right == 'V' || right == 'X') {
                        if (right == 'V') {
                            niceKidsWithPresentsCount++;
                        }
                        presentsCount--;
                        neighbourhood[newRow][newCol + 1] = '-';
                        if (presentsCount == 0) {break;}
                    }

                    if (up == 'V' || up == 'X') {
                        if (up == 'V') {
                            niceKidsWithPresentsCount++;
                        }
                        presentsCount--;
                        neighbourhood[newRow - 1][newCol] = '-';
                        if (presentsCount == 0) {break;}
                    }

                    if (down == 'V' || down == 'X') {
                        if (down == 'V') {
                            niceKidsWithPresentsCount++;
                        }
                        presentsCount--;
                        neighbourhood[newRow + 1][newCol] = '-';
                        if (presentsCount == 0) {break;}
                    }
            }

            if (presentsCount <= 0) {
                System.out.println("Santa ran out of presents!");
                break;
            }

            command = sc.nextLine();
        }

        // print
        for (char[] chars : neighbourhood) {
            for (char aChar : chars) {
                System.out.print(aChar + " ");
            }
            System.out.println();
        }

        int diff = totalNiceKidsCount - niceKidsWithPresentsCount;
        if (diff == 0) {
            System.out.println(String.format("Good job, Santa! %d happy nice kid/s.", niceKidsWithPresentsCount));
        } else {
            System.out.println(String.format("No presents for %d nice kid/s.", diff));
        }

    }

    private static boolean isValidPosition(int row, int col, char[][] matrix) {
        return row >= 0 && row < matrix.length && col >= 0 && col < matrix[row].length;
    }
}
