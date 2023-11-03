package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class PokeMon {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int initialPower = Integer.parseInt(sc.nextLine());
        int distance = Integer.parseInt(sc.nextLine());
        int exhaustionFactor = Integer.parseInt(sc.nextLine());

        double power = initialPower;
        int pokeCnt = 0;

        while (power >= distance) {
            power = power - distance;
            pokeCnt++;

            if (power == initialPower / 2.0) {
                if (exhaustionFactor != 0) {
                    power = (int) power / exhaustionFactor;
                }
            }
        }
        System.out.println((int)power);
        System.out.println(pokeCnt);
    }
}
