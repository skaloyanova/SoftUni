package z_Exam_20200628;

import java.util.Arrays;
import java.util.Scanner;

public class Snake {
    public static void main(String[] args) {

        final char SNAKE = 'S';
        final char FOOD = '*';
        final char TRAIL = '.';

        //input
        Scanner sc = new Scanner(System.in);
        int fieldSize = Integer.parseInt(sc.nextLine());

        char[][] field = new char[fieldSize][fieldSize];

        for (int i = 0; i < fieldSize; i++) {
            field[i] = sc.nextLine().toCharArray();
        }

        //logic
        int snakePosX = 0;
        int snakePosY = 0;
        boolean snakeFound = false;

        for (int i = 0; i < fieldSize; i++) {
            for (int j = 0; j < fieldSize; j++) {
                if (field[i][j] == SNAKE) {
                    snakePosX = i;
                    snakePosY = j;
                    snakeFound = true;
                    break;
                }
            }
            if (snakeFound) {
                break;
            }
        }

        int foodCount = 0;

        while (true) {
            String action = sc.nextLine();

            field[snakePosX][snakePosY] = TRAIL;

            switch (action) {
                case "up":
                    snakePosX--;
                    break;
                case "down":
                    snakePosX++;
                    break;
                case "left":
                    snakePosY--;
                    break;
                case "right":
                    snakePosY++;
                    break;
            }

            if (notValidPosition(snakePosX, snakePosY, fieldSize)) {
                break;
            } else {
                if (field[snakePosX][snakePosY] == FOOD) {
                    foodCount++;

                    if (foodCount >= 10) {
                        field[snakePosX][snakePosY] = SNAKE;
                        break;
                    }
                }
                if (field[snakePosX][snakePosY] == 'B') {
                    field[snakePosX][snakePosY] = TRAIL;
                    int[] endOfLairPos = findEndOfLair(field);
                    snakePosX = endOfLairPos[0];
                    snakePosY = endOfLairPos[1];
                }
            }
        }

        //output
        if (notValidPosition(snakePosX, snakePosY, fieldSize)) {
            System.out.println("Game over!");
        }

        if (foodCount >= 10) {
            System.out.println("You won! You fed the snake.");
        }

        System.out.println("Food eaten: " + foodCount);

        for (int i = 0; i < fieldSize; i++) {
            System.out.println(Arrays.toString(field[i]).replaceAll("[\\[\\], ]", ""));
        }

    }

    private static int[] findEndOfLair(char[][] field) {
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field[i].length; j++) {
                if (field[i][j] == 'B') {
                    return new int[]{i, j};
                }
            }
        }
        return new int[]{0,0};
    }

    private static boolean notValidPosition(int snakePosX, int snakePosY, int fieldSize) {
        return snakePosX < 0 || snakePosX >= fieldSize
                || snakePosY < 0 || snakePosY >= fieldSize;
    }
}
