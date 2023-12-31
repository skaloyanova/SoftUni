package k_ObjectsAndClasses;

import java.math.BigInteger;
import java.util.Scanner;

public class BigFactorial {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        BigInteger factorial = new BigInteger("1");

        for (int i = 2; i <= n; i++) {
            factorial = factorial.multiply(new BigInteger(String.valueOf(i)));
        }

        System.out.println(factorial);
    }
}
