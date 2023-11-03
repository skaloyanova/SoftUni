package p_FunctionalProgramming_Exercises;

import java.util.*;
import java.util.function.BiPredicate;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class ListOfPredicates {
    // for Var 2 only
    private static BiPredicate<Integer, Integer> predicate = (f, s) -> f % s == 0;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int numCount = Integer.parseInt(sc.nextLine());

        Set<Integer> sequence = Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toSet());

        /*------------------------------------*/
        // Variant 1

        // create a list with all numbers to be tested
        List<Integer> numbers = new ArrayList<>();

        for (int i = 1; i <= numCount; i++) {
            numbers.add(i);
        }

        // create a list with all Predicates
        List<Predicate<Integer>> allPredicates = new ArrayList<>();

        for (int num : sequence) {
            Predicate<Integer> divideBy = x -> x % num == 0;
            allPredicates.add(divideBy);
        }

        // filter numbers and print them
        numbers.stream()
                .filter(allPredicates.stream()
                        .reduce(x -> true, Predicate::and))
                .forEach(e -> System.out.print(e + " "));

        /*------------------------------------*/
        // Variant 2
//        checkNumbers(1, sequence, numCount);
    }

    private static void checkNumbers(int num, Set<Integer> sequence, int numCount) {
        if (num > numCount) {
            return;
        }

        boolean isValid = true;

        for (Integer integer : sequence) {
            if (!predicate.test(num, integer)) {
                isValid = false;
            }
        }

        if (isValid) {
            System.out.print(num + " ");
        }

        checkNumbers(num + 1, sequence, numCount);
    }
}
