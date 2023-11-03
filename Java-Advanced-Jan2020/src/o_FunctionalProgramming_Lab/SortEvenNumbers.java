package o_FunctionalProgramming_Lab;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class SortEvenNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Integer> numbers = Arrays.stream(sc.nextLine().split(", "))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        Predicate<Integer> isEven = (x) -> x % 2 == 0;

        String output = numbers.stream()
                .filter(isEven)
                .map(e -> String.valueOf(e))
                .collect(Collectors.joining(", "));

        String outputSorted = numbers.stream()
                .filter(isEven)
                .sorted()
                .map(e -> e.toString())
                .collect(Collectors.joining(", "));

        System.out.println(output);
        System.out.println(outputSorted);
    }
}
