package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class SpiceMustFlow {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int initialSource = Integer.parseInt(sc.nextLine());

        int currentDayLimit = initialSource;
        int spicesCollected = 0;
        int days = 0;

        if (initialSource < 100) {
            System.out.println(days);
            System.out.println(spicesCollected);
        } else {
            while (true) {
                spicesCollected += currentDayLimit - 26;
                days++;

                currentDayLimit -= 10;

                if (currentDayLimit < 100) {
                    spicesCollected -= 26;
                    break;
                }
            }

            System.out.println(days);
            System.out.println(spicesCollected);
        }
    }
}
