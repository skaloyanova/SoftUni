package o_FunctionalProgramming_Lab;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.function.Function;
import java.util.function.UnaryOperator;
import java.util.stream.Collectors;

public class AddVAT {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        UnaryOperator<Double> addVAT = (x) -> x * 1.2;
        Function<Double, String> formatTo2ndDigit = (x) -> String.format("%.2f", x);

        List<Double> input = Arrays.stream(sc.nextLine().split(", "))
                .map(Double::parseDouble)
                .collect(Collectors.toList());

        System.out.println("Prices with VAT:");
        input.stream()
                .map(addVAT)
                .map(formatTo2ndDigit)
                .forEach(e -> System.out.println(e));

    }
}
