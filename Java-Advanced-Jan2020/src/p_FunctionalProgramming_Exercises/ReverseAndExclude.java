package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.function.DoubleUnaryOperator;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class ReverseAndExclude {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Integer> numbers = Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int n = Integer.parseInt(sc.nextLine());

        Predicate<Integer> divisibleByN = x -> x % n == 0;

        Function<List<Integer>, List<Integer>> reverse = x -> {
            for (int i = 0; i < x.size() / 2; i++) {
                int temp = x.get(i);
                int index2 = x.size() - 1 - i;

                x.set(i, x.get(index2));
                x.set(index2, temp);
            }
            return x;
        };

        reverse.apply(numbers);
        numbers.stream().filter(divisibleByN.negate()).forEach(e -> System.out.print(e + " "));
    }
}
