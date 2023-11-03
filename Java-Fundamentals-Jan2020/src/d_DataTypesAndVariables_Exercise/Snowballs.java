package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class Snowballs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int snowballCnt = Integer.parseInt(sc.nextLine());

        String bestResult = "";
        double bestValue = 0;

        for (int i = 0; i < snowballCnt; i++) {
            int snowballSnow = Integer.parseInt(sc.nextLine());
            int snowballTime = Integer.parseInt(sc.nextLine());
            int snowballQuality = Integer.parseInt(sc.nextLine());

            double snowballValue = Math.pow((snowballSnow / snowballTime), snowballQuality);

            if (snowballValue > bestValue) {
                bestValue = snowballValue;
                bestResult = String.format("%d : %d = %.0f (%d)",
                        snowballSnow, snowballTime, snowballValue, snowballQuality);
            }
        }
        System.out.println(bestResult);
    }
}
