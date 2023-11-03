package d_MultidimensionalArrays_Exercises;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class StringMatrixRotation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<String> input = new ArrayList<>();

        int degree = Integer.parseInt(sc.nextLine().replaceAll("[^0-9]+", ""));
        degree = degree % 360;

        String command = sc.nextLine();
        int maxSize = 0;

        while (!"END".equals(command)) {
            input.add(command);
            if (command.length() > maxSize) {
                maxSize = command.length();
            }
            command = sc.nextLine();
        }

        char[][] words = new char[input.size()][maxSize];

        for (int row = 0; row < words.length; row++) {
            for (int col = 0; col < words[row].length; col++) {
                if (col < input.get(row).length()) {
                    words[row][col] = input.get(row).charAt(col);
                } else {
                    words[row][col] = ' ';
                }
            }
        }

        //print
        switch (degree) {
            case 0: printMatrix0(words); break;
            case 90: printMatrix90(words); break;
            case 180: printMatrix180(words); break;
            case 270: printMatrix270(words); break;
        }
    }

    private static void printMatrix0(char[][] words) {
        for (int row = 0; row < words.length; row++) {
            for (int col = 0; col < words[row].length; col++) {
                System.out.print(words[row][col]);
            }
            System.out.println();
        }
    }

    private static void printMatrix90(char[][] words) {
        for (int col = 0; col < words[0].length; col++) {
            for (int row = words.length - 1; row >= 0; row--) {
                System.out.print(words[row][col]);
            }
            System.out.println();
        }
    }

    private static void printMatrix180(char[][] words) {
        for (int row = words.length - 1; row >= 0; row--) {
            for (int col = words[row].length - 1; col >= 0; col--) {
                System.out.print(words[row][col]);
            }
            System.out.println();
        }
    }

    private static void printMatrix270(char[][] words) {
        for (int col = words[0].length - 1; col >= 0; col--) {
            for (int row = 0; row < words.length; row++) {
                System.out.print(words[row][col]);
            }
            System.out.println();
        }
    }
}
