package o_FunctionalProgramming_Lab;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Predicate;

public class CountUppercaseWords {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] input = sc.nextLine().split("\\s+");

        Predicate<String> isFirstLetterCapital = x -> Character.isUpperCase(x.charAt(0));

        long count = Arrays.stream(input)
                .filter(isFirstLetterCapital)
                .count();

        System.out.println(count);

        Arrays.stream(input)
                .filter(x -> Character.isUpperCase(x.charAt(0)))
                .forEach(x -> System.out.println(x));

    }
}
