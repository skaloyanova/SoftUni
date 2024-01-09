package b_workingWithAbstraction_Exercises.jediGalaxy;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] dimensions = readPosition(scanner.nextLine());
        int rows = dimensions[0];
        int cols = dimensions[1];

        Galaxy galaxy = new Galaxy(rows, cols, 0);

        String command = scanner.nextLine();
        long starsPowerCollected = 0;

        while (!command.equals("Let the Force be with you")) {
            int[] jediPosition = readPosition(command);
            int[] evilPosition = readPosition(scanner.nextLine());

            int jediRow = jediPosition[0];
            int jediCol = jediPosition[1];

            int evilRow = evilPosition[0];
            int evilCol = evilPosition[1];

            galaxy.destroyStars(evilRow, evilCol);

            starsPowerCollected += galaxy.collectStars(jediRow, jediCol);

            command = scanner.nextLine();
        }

        System.out.println(starsPowerCollected);

    }

    private static int[] readPosition(String command) {
        return Arrays.stream(command.split(" ")).mapToInt(Integer::parseInt).toArray();
    }
}
