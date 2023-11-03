package MidRetake2020_04_07;

import java.util.Scanner;

public class CounterStrike {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int energy = Integer.parseInt(sc.nextLine());
        int wonCnt = 0;

        String input = sc.nextLine();

        while (!"End of battle".equals(input)) {
            int distance = Integer.parseInt(input);

            if (energy < distance) {
                System.out.printf("Not enough energy! Game ends with %d won battles and %d energy", wonCnt, energy);
                return;
            } else {
                energy -= distance;
                wonCnt++;
                if (wonCnt % 3 == 0) {
                    energy += wonCnt;
                }
            }

            input = sc.nextLine();
        }

        System.out.printf("Won battles: %d. Energy left: %d", wonCnt, energy);
    }
}
