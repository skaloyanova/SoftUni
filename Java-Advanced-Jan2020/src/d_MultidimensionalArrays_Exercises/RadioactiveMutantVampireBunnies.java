package d_MultidimensionalArrays_Exercises;

import java.util.Arrays;
import java.util.Scanner;

public class RadioactiveMutantVampireBunnies {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int rows = sc.nextInt();
        int cols = sc.nextInt();
        sc.nextLine();

        char[][] lair = new char[rows][cols];

        for (int i = 0; i < lair.length; i++) {
            char[] input = sc.nextLine().toCharArray();
            for (int j = 0; j < lair[i].length; j++) {
                lair[i][j] = input[j];
            }
        }

        char[] directions = sc.nextLine().toCharArray();

        //find the Player
        int playerRow = -1;
        int playerCol = -1;
        for (int row = 0; row < lair.length; row++) {
            for (int col = 0; col < lair[row].length; col++) {
                if (lair[row][col] == 'P') {
                    playerRow = row;
                    playerCol = col;
                    lair[playerRow][playerCol] = '.';
                }
            }
        }

        boolean playerWon = false;
        boolean playerLost = false;
        for (char direction : directions) {
            switch (direction) {
                case 'U':
                    playerRow--;
                    if (isOutOfLair(rows, cols, playerRow, playerCol)) {
                        playerWon = true;
                        playerRow++;
                    }
                    break;
                case 'D':
                    playerRow++;
                    if (isOutOfLair(rows, cols, playerRow, playerCol)) {
                        playerWon = true;
                        playerRow--;
                    }
                    break;
                case 'L':
                    playerCol--;
                    if (isOutOfLair(rows, cols, playerRow, playerCol)) {
                        playerWon = true;
                        playerCol++;
                    }
                    break;
                case 'R':
                    playerCol++;
                    if (isOutOfLair(rows, cols, playerRow, playerCol)) {
                        playerWon = true;
                        playerCol--;
                    }
                    break;
            }

            // increase bunny population
            for (int row = 0; row < lair.length; row++) {
                for (int col = 0; col < lair[row].length; col++) {
                    if (lair[row][col] == 'B') {
                        increaseBunnies(lair, row, col);    //set value "a" for new bunnies
                    }
                }
            }

            // replace the pre-set value of 'a' with 'B'
            for (int row = 0; row < lair.length; row++) {
                for (int col = 0; col < lair[row].length; col++) {
                    if (lair[row][col] == 'a') {
                        lair[row][col] = 'B';
                    }
                }
            }

            if (playerWon) {
                break;
            } else if (lair[playerRow][playerCol] == 'B') {
                playerLost = true;
                break;
            }
        }

        //output
        Arrays.stream(lair).forEach(e -> {
            System.out.println(Arrays.toString(e).replaceAll("[\\[\\], ]", ""));
        });
        if (playerWon) {
            System.out.println("won: " + playerRow + " " + playerCol);
        } else if (playerLost) {
            System.out.println("dead: " + playerRow + " " + playerCol);
        }
    }

    private static void increaseBunnies(char[][] lair, int row, int col) {  //set value "a" for new bunnies
        int newBunny1 = row - 1;
        int newBunny2 = row + 1;
        int newBunny3 = col - 1;
        int newBunny4 = col + 1;

        if (isValidIndex(newBunny1, lair.length) && lair[newBunny1][col] != 'B') {
            lair[newBunny1][col] = 'a';
        }
        if (isValidIndex(newBunny2, lair.length) && lair[newBunny2][col] != 'B') {
            lair[newBunny2][col] = 'a';
        }
        if (isValidIndex(newBunny3, lair[row].length) && lair[row][newBunny3] != 'B') {
            lair[row][newBunny3] = 'a';
        }
        if (isValidIndex(newBunny4, lair[row].length) && lair[row][newBunny4] != 'B') {
            lair[row][newBunny4] = 'a';
        }
    }

    private static boolean isValidIndex(int newBunny, int length) {
        return newBunny >= 0 && newBunny < length;
    }

    private static boolean isOutOfLair(int rows, int cols, int playerRow, int playerCol) {
        return playerRow < 0 || playerRow >= rows || playerCol < 0 || playerCol >= cols;
    }
}
