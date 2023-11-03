package z_Exam_20191023_Demo;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class TheGarden {
    private static char[][] garden;
    private static int harmedCount;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        // fill the Garden with vegetables
        garden = new char[n][];

        for (int i = 0; i < n; i++) {
            garden[i] = sc.nextLine().replaceAll("\\s+", "").toCharArray();
        }

        // create a Map to keep the harvested products
        Map<Character, Integer> harvest = new HashMap<>() {{
            put('C', 0);
            put('P', 0);
            put('L', 0);
        }};

        // get and execute commands
        String input = sc.nextLine();
        while (!"End of Harvest".equals(input)) {
            String[] tokens = input.split("\\s");
            int row = Integer.parseInt(tokens[1]);
            int col = Integer.parseInt(tokens[2]);

            if ("Harvest".equals(tokens[0]) && isValidIndex(row, col) && hasVegetable(row, col)) {
                harvest.put(garden[row][col], harvest.get(garden[row][col]) + 1);
                garden[row][col] = ' ';

            } else if ("Mole".equals(tokens[0]) && isValidIndex(row, col)) {
                String direction = tokens[3];
                moleAction(row, col, direction);
            }

            input = sc.nextLine();
        }

        // print Garden
        for (char[] chars : garden) {
            for (char aChar : chars) {
                System.out.print(aChar + " ");
            }
            System.out.println();
        }

        // print Count of products
        System.out.println("Carrots: " + harvest.get('C'));
        System.out.println("Potatoes: " + harvest.get('P'));
        System.out.println("Lettuce: " + harvest.get('L'));
        System.out.println("Harmed vegetables: " + harmedCount);
    }

    private static void moleAction(int row, int col, String direction) {
        if (!isValidIndex(row, col)) {
            return;
        }
        if (hasVegetable(row, col)) {
            harmedCount++;
            garden[row][col] = ' ';
        }

        switch (direction) {
            case "up":
                moleAction(row - 2, col, direction);
                break;
            case "down":
                moleAction(row + 2, col, direction);
                break;
            case "left":
                moleAction(row, col - 2, direction);
                break;
            case "right":
                moleAction(row, col + 2, direction);
                break;
        }
    }

    private static boolean hasVegetable(int row, int col) {
        return garden[row][col] != ' ';
    }

    private static boolean isValidIndex(int row, int col) {
        return row >= 0 && row < garden.length && col >= 0 && col < garden[row].length;
    }
}
