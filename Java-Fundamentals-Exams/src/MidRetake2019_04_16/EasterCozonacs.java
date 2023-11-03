package MidRetake2019_04_16;

import java.util.Scanner;

public class EasterCozonacs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        double budget = Double.parseDouble(sc.nextLine());
        double flourPrice = Double.parseDouble(sc.nextLine());

        double eggPrice = 0.75 * flourPrice;
        double milkPrice = (1.25 * flourPrice) / 4;

        double cakePrice = flourPrice + eggPrice + milkPrice;
        int coloredEggs = 0;
        int cakeCnt = 0;

        while (budget >= cakePrice) {
            budget -= cakePrice;
            cakeCnt++;
            coloredEggs += 3;

            if (cakeCnt % 3 == 0) {
                coloredEggs -= cakeCnt - 2;
            }
        }

        System.out.printf("You made %d cozonacs! Now you have %d eggs and %.2fBGN left.", cakeCnt, coloredEggs, budget);

    }
}
