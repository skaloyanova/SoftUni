package z_Exam_20200222;

import java.util.Scanner;

public class ReVolt {
    private static char[][] field;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int size = Integer.parseInt(sc.nextLine());
        int cmdCount = Integer.parseInt(sc.nextLine());

        field = new char[size][size];

        // player's position - > 0 - row, 1 - col
        int[] pos = new int[2];

        for (int i = 0; i < size; i++) {
            String line = sc.nextLine();
            field[i] = line.toCharArray();
            if (line.contains("f")) {
                pos[0] = i;
                pos[1] = line.indexOf('f');
            }
        }

        //clear original Player's position
        field[pos[0]][pos[1]] = '-';

        boolean finished = false;

        for (int i = 0; i < cmdCount; i++) {
            String direction = sc.nextLine();

            getNewPosition(pos, direction);

            if (field[pos[0]][pos[1]] == 'F') {
                finished = true;
                break;
            }

            actionOnNewPosition(pos, direction);

            if (field[pos[0]][pos[1]] == 'F') {
                finished = true;
                break;
            }
        }

        field[pos[0]][pos[1]] = 'f';

        // print
        if (finished) {
            System.out.println("Player won!");
        } else {
            System.out.println("Player lost!");
        }

        for (char[] chars : field) {
            for (char aChar : chars) {
                System.out.print(aChar);
            }
            System.out.println();
        }
    }

    private static void actionOnNewPosition(int[] pos, String direction) {
        char newPositionValue = field[pos[0]][pos[1]];

        switch (newPositionValue) {
            case 'B':
                getNewPosition(pos, direction);
//                actionOnNewPosition(pos, direction);
                break;
            case 'T':
                if (direction.equals("up")) {
                    direction = "down";
                } else if (direction.equals("down")) {
                    direction = "up";
                } else if (direction.equals("left")) {
                    direction = "right";
                } else if (direction.equals("right")) {
                    direction = "left";
                }
                getNewPosition(pos, direction);
//                actionOnNewPosition(pos, direction);
                break;
        }
    }

    private static void getNewPosition(int[] pos, String direction) {
        int row = pos[0];
        int col = pos[1];

        switch (direction) {
            case "up":
                row--;
                if (row == -1) {
                    row = field.length - 1;
                }
                break;
            case "down":
                row++;
                if (row == field.length) {
                    row = 0;
                }
                break;
            case "left":
                col--;
                if (col == -1) {
                    col = field[row].length - 1;
                }
                break;
            case "right":
                col++;
                if (col == field[row].length) {
                    col = 0;
                }
                break;
        }

        pos[0] = row;
        pos[1] = col;
    }
}
