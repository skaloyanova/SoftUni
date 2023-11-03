package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class PoundsToDollars {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double gbp = Double.parseDouble(sc.nextLine());

        double usd = gbp * 1.31;

        System.out.println(String.format("%.3f", usd));
    }
}
