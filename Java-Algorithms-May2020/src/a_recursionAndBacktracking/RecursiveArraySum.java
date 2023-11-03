package a_recursionAndBacktracking;

import java.util.Arrays;
import java.util.Scanner;

public class RecursiveArraySum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] numbers = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        //recursive solution
        System.out.println(sum(numbers, 0));
//        System.out.println("Recursion sum: " + sum(numbers, 0));

//        //iteration solution
//        int sum = 0;
//        for (int number : numbers) {
//            sum += number;
//        }
//        System.out.println("Iteration sum: " + sum);
    }

    private static int sum(int[] numbers, int index) {
        if (index == numbers.length - 1) {
            return numbers[index];
        }
        return numbers[index] + sum(numbers, index + 1);
    }
}
