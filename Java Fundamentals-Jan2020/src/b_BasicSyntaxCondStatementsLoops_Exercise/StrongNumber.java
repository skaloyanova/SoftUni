package b_BasicSyntaxCondStatementsLoops_Exercise;

import java.util.Scanner;

public class StrongNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        /* VARIANT 1
        int num = Integer.parseInt(sc.nextLine());

        int digits = String.valueOf(num).length();

        int sum = 0;
        int x = 1;

        // last digit will be "(num / 1) % 10", previous one "(num / 10) % 10", prev-prev "(num / 100) % 10" and so on
        for (int i = 0; i < digits; i++) {

            int currentDigit = (num / x) % 10;

            int currentFactorial = 1;

            for (int j = 1; j <= currentDigit; j++) {
                currentFactorial = currentFactorial * j;
            }

            sum = sum + currentFactorial;

            //prepare the previous digit
            x = x * 10;
        }


        if (num == sum) {
            System.out.println("yes");
        } else {
            System.out.println("no");
        }

        */

        // Variant 2
        String numTx = sc.nextLine();
        int sum = 0;

        for (int i = 0; i < numTx.length(); i++) {
            //get a digit
            int currentDigit = Integer.parseInt("" + numTx.charAt(i));

            int currentFactorial = 1;

            for (int j = 1; j <= currentDigit; j++) {
                currentFactorial = currentFactorial * j;
            }

            sum = sum + currentFactorial;
        }

        if (Integer.parseInt(numTx) == sum) {
            System.out.println("yes");
        } else {
            System.out.println("no");
        }
    }
}
