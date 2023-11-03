package q_BasicAlgorithms_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class RecursiveArraySum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] numbers = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        System.out.println(sum(numbers, 0));
    }

    private static int sum(int[] numbers, int i) {
        if (i == numbers.length) {
            return 0;
        }
        return numbers[i] + sum(numbers, i + 1);
    }
}
