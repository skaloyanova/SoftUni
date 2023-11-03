package z_Exam_20180827_Retake_archived;

import java.util.Scanner;

public class BombField {
    private static char[][] field;
    private static int bombs;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int size = Integer.parseInt(sc.nextLine());
        String[] directions = sc.nextLine().split(",");

        String[][] field = new String[size][size];

        //position of sapper
        int row = -1;
        int col = -1;

        for (int i = 0; i < size; i++) {
            String[] line = sc.nextLine().split("\\s+");
            for (int j = 0; j < line.length; j++) {
                field[i][j] = line[j];

                if (line[j].equals("s")) {
                    row = i;
                    col = j;
                }
                if (line[j].equals("B")) {
                    bombs++;
                }
            }

        }

        for (String direction : directions) {
            switch (direction) {
                case "up":
                    row--;
                    if (row == -1) {
                        row++;
                        continue;
                    }
                    break;
                case "down":
                    row++;
                    if (row == field.length) {
                        row--;
                        continue;
                    }
                    break;
                case "left":
                    col--;
                    if (col == -1) {
                        col++;
                        continue;
                    }
                    break;
                case "right":
                    col++;
                    if (col == field[row].length) {
                        col--;
                        continue;
                    }
                    break;
            }

            if ("B".equals(field[row][col])) {
                field[row][col] = "+";
                bombs--;
                System.out.println("You found a bomb!");
                if (bombs == 0) {
                    System.out.println("Congratulations! You found all bombs!");
                    return;
                }
            } else if ("e".equals(field[row][col])) {
                System.out.println(String.format("END! %d bombs left on the field", bombs));
                return;
            }
        }

        System.out.println(String.format("%d bombs left on the field. Sapper position: (%d,%d)", bombs, row, col));
    }
}
