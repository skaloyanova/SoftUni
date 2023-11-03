package p_FunctionalProgramming_Exercises;

import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Function;

public class CustomMinFunction {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Function<int[], Integer> minCustom = nums -> {
            int min = Integer.MAX_VALUE;
            for (int i = 0; i < nums.length; i++) {
                if (nums[i] < min) {
                    min = nums[i];
                }
            }
            return min;
        };

        int[] numbers = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        System.out.println(minCustom.apply(numbers));

    }
}
