package f_Arrays_Exercise;

import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] input = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int maxLength = 1;
        int length = 1;
        int indexToRepeat = 0;

        for (int i = 0; i < input.length - 1; i++) {
            if (input[i] == input[i + 1]) {
                length++;
            } else {
                length = 1;
            }
            if (length > maxLength) {
                maxLength = length;
                indexToRepeat = i;
            }
        }

        // if there is no equal sequence, it will print the 1st element, as it is the most left with length 1
        for (int i = 0; i < maxLength; i++) {
            System.out.print(input[indexToRepeat] + " ");
        }
    }
}
