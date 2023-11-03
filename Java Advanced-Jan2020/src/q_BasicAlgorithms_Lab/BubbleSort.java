package q_BasicAlgorithms_Lab;

import java.util.Arrays;

public class BubbleSort {
    public static void main(String[] args) {
        int[] numbers = {7, 3, 4, 2, 5, 6};
        System.out.println(Arrays.toString(numbers) + " - before sorting");

        /*-----------*/
        // Variant 1
//        boolean swapped = true;
//
//        while (swapped) {
//            swapped = false;
//            for (int i = 0; i < numbers.length - 1; i++) {
//                int first = numbers[i];
//                int second = numbers[i + 1];
//
//                if (first > second) {
//                    numbers[i] = second;
//                    numbers[i + 1] = first;
//                    swapped = true;
//                }
//            }
//        }
//        System.out.println(Arrays.toString(numbers) + " - after sorting < Variant 1 >");
        /*-----------*/
        // Variant 2
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i + 1; j < numbers.length; j++) {
                if (numbers[i] > numbers[j]) {
                    int tempNumber = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tempNumber;
                }
            }
        }
        System.out.println(Arrays.toString(numbers) + " - after sorting < Variant 2 >");
        /*-----------*/

    }
}
