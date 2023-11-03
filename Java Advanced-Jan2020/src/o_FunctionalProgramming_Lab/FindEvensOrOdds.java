package o_FunctionalProgramming_Lab;

import java.util.Scanner;
import java.util.function.Predicate;

public class FindEvensOrOdds {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] tokens = sc.nextLine().split("\\s+");
        int lowBound = Integer.parseInt(tokens[0]);
        int highBound = Integer.parseInt(tokens[1]);
        String type = sc.nextLine();

        Predicate<Integer> evenOrOdd = x -> {
            if ("even".equals(type)) {
                return x % 2 == 0;
            } else {
                return x % 2 != 0;
            }
        };

        for (int i = lowBound; i <= highBound; i++) {
            if (evenOrOdd.test(i)) {
                System.out.print(i + " ");
            }
        }
    }
}
