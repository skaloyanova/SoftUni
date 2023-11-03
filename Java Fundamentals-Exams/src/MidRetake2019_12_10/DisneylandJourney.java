package MidRetake2019_12_10;

import java.util.Scanner;

public class DisneylandJourney {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        double journeyCost = Double.parseDouble(sc.nextLine());
        int months = Integer.parseInt(sc.nextLine());

        double savedMoney = 0.25 * journeyCost;     //saved after month 1

        for (int i = 2; i <= months; i++) {
            if (i % 2 != 0) {
                savedMoney -= 0.16 * savedMoney;
            }
            if (i % 4 == 0) {
                savedMoney += 0.25 * savedMoney;
            }

            savedMoney += 0.25 * journeyCost;
        }

        //output
        double diff = savedMoney - journeyCost;
        if (diff >= 0) {
            System.out.printf("Bravo! You can go to Disneyland and you will have %.2flv. for souvenirs.", diff);
        } else {
            System.out.printf("Sorry. You need %.2flv. more.", Math.abs(diff));
        }
    }
}
