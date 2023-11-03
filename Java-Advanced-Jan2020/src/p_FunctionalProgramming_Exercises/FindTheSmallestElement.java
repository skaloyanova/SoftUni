package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Function;

public class FindTheSmallestElement {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] numbers = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        Function<int[], Integer> smallestNumber = nums -> {
            int min = Integer.MAX_VALUE;
            int index = -1;
            for (int i = 0; i < nums.length; i++) {
                if (nums[i] <= min) {
                    min = nums[i];
                    index = i;
                }
            }
            return index;
        };

        System.out.println(smallestNumber.apply(numbers));
    }
}
