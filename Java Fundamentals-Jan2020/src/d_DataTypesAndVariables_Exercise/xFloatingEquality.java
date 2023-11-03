package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xFloatingEquality {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double num1 = Double.parseDouble(sc.nextLine());
        double num2 = Double.parseDouble(sc.nextLine());

        double eps = 0.000001;

        if (Math.abs(num1 - num2) <= 0.000001) {
            System.out.println("True");
        } else {
            System.out.println("False");
        }
    }
}
