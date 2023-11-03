package o_FunctionalProgramming_Lab;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Function;

public class SumNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] inputNums = sc.nextLine().split(", ");

        Function<String, Integer> stringIntegerFunction = (x) -> Integer.parseInt(x);

        int sum = Arrays.stream(inputNums)
                .mapToInt(stringIntegerFunction::apply)
                .sum();

        long count = Arrays.stream(inputNums)
                .mapToInt(stringIntegerFunction::apply)
                .count();

        System.out.println("Count = " + count);
        System.out.println("Sum = " + sum);
    }
}
