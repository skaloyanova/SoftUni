package MidRetake2019_08_06;

import java.util.Scanner;

public class BlackFlag {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int days = Integer.parseInt(sc.nextLine());
        int dailyPlunder = Integer.parseInt(sc.nextLine());
        double expectedPlunder = Double.parseDouble(sc.nextLine());

        double totalPlunder = 0;

        //Every third day ->  +50% of the daily plunder
        //Every fifth -> -30% of their total plunder

        for (int i = 1; i <= days; i++) {
            totalPlunder += dailyPlunder;

            if (i % 3 == 0) {
                totalPlunder += 0.50 * dailyPlunder;
            }

            if (i % 5 == 0) {
                totalPlunder -= 0.30 * totalPlunder;
            }
        }

        if (totalPlunder >= expectedPlunder) {
            System.out.printf("Ahoy! %.2f plunder gained.", totalPlunder);
        } else {
            double percent = totalPlunder * 100.0 / expectedPlunder;
            System.out.printf("Collected only %.2f%% of the plunder.", percent);
        }
    }
}
