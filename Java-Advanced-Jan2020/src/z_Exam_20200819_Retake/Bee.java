package z_Exam_20200819_Retake;

import java.util.Arrays;
import java.util.Scanner;

public class Bee {
    public static void main(String[] args) {
        final char BEE = 'B';
        final char FLOWER = 'f';
        final char BONUS = 'O';
        final char EMPTY = '.';

        Scanner sc = new Scanner(System.in);

        int size = Integer.parseInt(sc.nextLine());

        char[][] territory = new char[size][size];

        int[] beePosition = new int[2];     //idx0 -> row, idx1 -> col

        for (int i = 0; i < size; i++) {
            String line = sc.nextLine();
            territory[i] = line.toCharArray();

            if (line.contains(String.valueOf(BEE))) {
                beePosition[0] = i;
                beePosition[1] = line.indexOf(String.valueOf(BEE));
            }
        }

        int flowersCount = 0;
        String command = sc.nextLine();

        while (!"End".equals(command)) {
            //clear the spot, where the bee is currently located
            territory[beePosition[0]][beePosition[1]] = EMPTY;

            //get the new position of the bee, depending on the command
            beePosition = getNewPosition(beePosition, command);

            //verify if the new position is valid
            if (notValidPosition(beePosition, size)) {
                break;
            }

            if (territory[beePosition[0]][beePosition[1]] == BONUS) {
                territory[beePosition[0]][beePosition[1]] = EMPTY;
                beePosition = getNewPosition(beePosition, command);
            }

            if (territory[beePosition[0]][beePosition[1]] == FLOWER) {
                    flowersCount++;
            }

            territory[beePosition[0]][beePosition[1]] = BEE;

            command = sc.nextLine();
        }

        //output
        if (notValidPosition(beePosition, size)) {
            System.out.println("The bee got lost!");
        }

        if (flowersCount < 5) {
            System.out.printf("The bee couldn't pollinate the flowers, she needed %d flowers more%n", 5 - flowersCount);
        } else {
            System.out.printf("Great job, the bee manage to pollinate %d flowers!%n", flowersCount);
        }

        //print matrix
        Arrays.stream(territory)
                .forEach(row -> System.out.println(Arrays.toString(row).replaceAll("[\\[\\], ]", "")));
    }

    private static int[] getNewPosition(int[] beePosition, String command) {
        int beePosRow = beePosition[0];
        int beePosCol = beePosition[1];

        switch (command) {
            case "up": beePosRow--; break;
            case "down": beePosRow++; break;
            case "left": beePosCol--; break;
            case "right": beePosCol++; break;
        }
        return new int[]{beePosRow,beePosCol};
    }

    private static boolean notValidPosition(int[] beePosition, int size) {
        int beePosRow = beePosition[0];
        int beePosCol = beePosition[1];
        return beePosRow < 0 || beePosCol < 0 || beePosRow >= size || beePosCol >= size;
    }
}
