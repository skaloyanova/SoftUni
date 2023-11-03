package c_DataTypesAndVariables_Lab;

import java.util.Scanner;

public class SpecialNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        for (int i = 1; i <= n; i++) {
            int sum = 0;
            for (int j = 0; j < String.valueOf(i).length(); j++) {
                String numberText = "" + i;
                int digit = Integer.parseInt("" + numberText.charAt(j));
                sum += digit;
            }

            if (sum == 5 || sum == 7 || sum == 11) {
                System.out.println(String.format("%d -> True", i));
            } else {
                System.out.println(String.format("%d -> False", i));
            }
        }

    }
}
