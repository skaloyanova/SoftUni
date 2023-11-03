package d_DataTypesAndVariables_Exercise;

import java.util.Scanner;

public class xRefactoringPrimeChecker {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        for (int i = 2; i <= n; i++) {
            boolean isPrime = true;
            for (int j = 2; j < i; j++) {
                if (i % j == 0) {
                    isPrime = false;
                    break;
                }
            }
            System.out.printf("%d -> %b%n", i, isPrime);
        }
    }
}

