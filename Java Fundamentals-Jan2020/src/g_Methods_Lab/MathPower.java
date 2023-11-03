package g_Methods_Lab;

import java.text.DecimalFormat;
import java.util.Scanner;

public class MathPower {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double num = Double.parseDouble(sc.nextLine());
        int power = Integer.parseInt(sc.nextLine());
        DecimalFormat df = new DecimalFormat("#.####");

        System.out.println(df.format(mathPower(num, power)));
    }

    private static double mathPower(double num, int power) {
        double result = 1;

        for (int i = 0; i < Math.abs(power); i++) {
            result *= num;
        }
        if (power < 0) {
            return 1.0 / result;
        } else if (power == 0) {
            return 1;
        } else {
            return result;
        }
    }
}
