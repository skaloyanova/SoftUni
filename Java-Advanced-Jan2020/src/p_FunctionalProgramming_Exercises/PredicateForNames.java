package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Predicate;

public class PredicateForNames {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int length = Integer.parseInt(sc.nextLine());

        Predicate<String> checkLength = x -> x.length() <= length;

        Arrays.stream(sc.nextLine().split("\\s+"))
                .filter(checkLength)
                .forEach(System.out::println);
    }
}
