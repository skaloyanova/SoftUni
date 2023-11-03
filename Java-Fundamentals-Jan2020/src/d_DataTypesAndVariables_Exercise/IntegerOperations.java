package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class IntegerOperations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int num1 = Integer.parseInt(sc.nextLine());
        int num2 = Integer.parseInt(sc.nextLine());
        int num3 = Integer.parseInt(sc.nextLine());
        int num4 = Integer.parseInt(sc.nextLine());

        int result = ((num1 + num2) / num3) * num4;

        System.out.println(result);
    }
}

