package x_ArchivedExercises;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class e02_BlurFilter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        //read input
        int blurAmount = Integer.parseInt(sc.nextLine());
        String[] tokens1 = sc.nextLine().split("\\s+");
        int rows = Integer.parseInt(tokens1[0]);
        int columns = Integer.parseInt(tokens1[1]);

        ArrayDeque<List<Integer>> matrix = new ArrayDeque<>();

        for (int i = 0; i < rows; i++) {
            List<Integer> row = Arrays
                    .stream(sc.nextLine().split("\\s+"))
                    .map(Integer::parseInt)
                    .collect(Collectors.toList());

            matrix.offer(row);
        }

        String[] tokens2 = sc.nextLine().split("\\s+");
        int pixelRow = Integer.parseInt(tokens2[0]);
        int pixelCol = Integer.parseInt(tokens2[1]);

        for (int i = 0; i < rows; i++) {
            if (i < pixelRow - 1 || i > pixelRow + 1) {
                System.out.println(matrix.poll().toString().replaceAll("[\\[\\],]", ""));
            } else {
                List<Integer> line = matrix.poll();
                for (int j = 0; j < columns; j++) {
                    if (j >= pixelCol - 1 && j <= pixelCol + 1) {
                        long number = (long)line.get(j) + (long)blurAmount;
                        System.out.print(number + " ");
                    } else {
                        System.out.print(line.get(j) + " ");
                    }
                }
                System.out.println();
            }
        }
    }
}
