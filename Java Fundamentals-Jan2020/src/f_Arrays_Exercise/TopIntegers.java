package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class TopIntegers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] input = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        for (int i = 0; i < input.length; i++) {
            boolean isMax = true;
            for (int j = i + 1; j < input.length; j++) {
                if (input[i] <= input[j]) {
                    isMax = false;
                    break;
                }
            }
            if (isMax) {
                System.out.print(input[i] + " ");
            }
        }
    }
}
