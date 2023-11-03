package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class ConvertMetersToKilometers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double meters = Double.parseDouble(sc.nextLine());

        double km = meters / 1000;

        System.out.printf("%.2f", km);
    }
}
