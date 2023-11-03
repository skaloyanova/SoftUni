package p_FunctionalProgramming_Exercises;

import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class CustomComparator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Comparator<Integer> sorter = (f, s) -> {
            int result = 0;

            if (isEven(f) && isEven(s)) {
                result = f.compareTo(s);
            } else if (!isEven(f) && !isEven(s)) {
                result = f.compareTo(s);
            } else if (isEven(f) && !isEven(s)) {
                result = -1;
            } else if (!isEven(f) && isEven(s)) {
                result = 1;
            }

            return result;
        };

        /*-----------------------------*/
        //VAR 1, using .sorted in stream

//        Arrays.stream(sc.nextLine().split("\\s+"))
//                .map(Integer::parseInt)
//                .sorted(sorter)
//                .forEach(e -> System.out.print(e + " "));

        /*-----------------------------*/
        //VAR 2, using Arrays.sort()

        List<Integer> numList = Arrays.stream(sc.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        Integer[] numbers = new Integer[numList.size()];
        for (int i = 0; i < numList.size(); i++) {
            numbers[i] = numList.get(i);
        }

        Arrays.sort(numbers, sorter);

        for (Integer number : numbers) {
            System.out.print(number + " ");
        }
        /*-----------------------------*/

    }

    private static boolean isEven(int a) {
        return a % 2 == 0;
    }
}
