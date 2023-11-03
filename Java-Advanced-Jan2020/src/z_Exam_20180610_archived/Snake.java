package z_Exam_20180610_archived;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class Snake {
    private static String[][] field;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int size = Integer.parseInt(sc.nextLine());
        ArrayDeque<String> directions = new ArrayDeque<>();     //queue
        Arrays.stream(sc.nextLine().split(", ")).forEach(directions::offer);

        field = new String[size][size];

        for (int i = 0; i < size; i++) {
            field[i] = sc.nextLine().split("\\s+");
        }

        // snake position -> [0] row, [1] col
        int[] pos = {-1, -1};

        int food = 0;

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (field[i][j].equals("s")) {
                    pos[0] = i;
                    pos[1] = j;
                }
                if (field[i][j].equals("f")) {
                    food++;
                }
            }
        }

        int length = 1;

        while (directions.size() > 0) {
            pos = getNewPosition(pos[0], pos[1], directions.poll());

            String cellValue = field[pos[0]][pos[1]];
            switch (cellValue) {
                case "e":
                    System.out.println("You lose! Killed by an enemy!");
                    return;
                case "f":
                    length++;
                    food--;
                    if (food == 0) {
                        System.out.println("You win! Final snake length is " + length);
                        return;
                    }
            }
        }

        // if no "return" till now, i.e. there are no more directions, but there is still food on the field
        System.out.println(String.format("You lose! There is still %d food to be eaten.", food));
    }

    private static int[] getNewPosition(int row, int col, String direction) {
        switch (direction) {
            case "up":
                row = row == 0 ? field.length - 1 : row - 1;
                break;
            case "down":
                row = row == field.length - 1 ? 0 : row + 1;
                break;
            case "left":
                col = col == 0 ? field[row].length - 1 : col - 1;
                break;
            case "right":
                col = col == field[row].length - 1 ? 0 : col + 1;
                break;
        }

        return new int[]{row, col};
    }
}
