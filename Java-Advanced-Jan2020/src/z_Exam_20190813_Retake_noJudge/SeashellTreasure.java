package z_Exam_20190813_Retake_noJudge;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class SeashellTreasure {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int rows = Integer.parseInt(sc.nextLine());

        char[][] beach = new char[rows][];

        for (int i = 0; i < rows; i++) {
            beach[i] = sc.nextLine().replaceAll(" ", "").toCharArray();
        }

        List<Character> collectedShells = new ArrayList<>();
        int stolenShells = 0;

        String input = sc.nextLine();
        while (!"Sunset".equals(input)) {
            String[] tokens = input.split("\\s+");
            int row = Integer.parseInt(tokens[1]);
            int col = Integer.parseInt(tokens[2]);

            if ("Collect".equals(tokens[0])) {
                if (isValidPosition(row, col, beach) && beach[row][col] != '-') {
                    collectedShells.add(beach[row][col]);
                    beach[row][col] = '-';
                }
            } else if ("Steal".equals(tokens[0])) {
                String direction = tokens[3];
                for (int i = 0; i < 4; i++) {
                    if (isValidPosition(row, col, beach) && beach[row][col] != '-') {
                        stolenShells++;
                        beach[row][col] = '-';
                    }
                    switch (direction) {
                        case "up": row--; break;
                        case "down": row++; break;
                        case "left": col--; break;
                        case "right": col++; break;
                    }
                }
            }

            input = sc.nextLine();
        }

        //print
        for (char[] row : beach) {
            for (char shell : row) {
                System.out.print(shell + " ");
            }
            System.out.println();
        }

        System.out.print("Collected seashells: " + collectedShells.size());
        if (collectedShells.size() > 0) {
            System.out.print(String.format(" -> %s", collectedShells.stream()
                    .map(e -> "" + e).collect(Collectors.joining(", "))));
        }
        System.out.println();
        System.out.println("Stolen seashells: " + stolenShells);

    }

    private static boolean isValidPosition(int r, int c, char[][] matrix) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
