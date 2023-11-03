package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xFromLeftToTheRight {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String text = sc.nextLine();

            int indexSpace = text.indexOf(' ');

            long num1 = Long.parseLong(text.substring(0, indexSpace));
            long num2 = Long.parseLong(text.substring(indexSpace + 1));

            // JUDGE GIVES 100/100 WHEN USING ABSOLUTE VALUE OF THE NUMBER, ELSE 25/100

            long maxNum = Math.abs(Math.max(num1, num2));

            int sum = 0;
            while (maxNum > 0) {
                sum += maxNum % 10;
                maxNum = maxNum / 10;
            }
            System.out.println(sum);
        }
    }
}
