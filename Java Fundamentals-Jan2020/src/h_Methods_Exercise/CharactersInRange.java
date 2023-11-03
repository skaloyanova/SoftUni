package h_Methods_Exercise;

import java.util.Scanner;

public class CharactersInRange {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        char c1 = sc.nextLine().charAt(0);
        char c2 = sc.nextLine().charAt(0);

        printCharsInRange(c1, c2);
    }

    private static void printCharsInRange(char symbol1, char symbol2) {
        int from = Math.min(symbol1, symbol2);
        int to = Math.max(symbol1, symbol2);

        for (int i = from + 1; i < to; i++) {
            System.out.print(String.format("%c ", i));
        }
    }
}
