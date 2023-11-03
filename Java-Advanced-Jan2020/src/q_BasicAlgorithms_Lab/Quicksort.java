package q_BasicAlgorithms_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class Quicksort {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] data = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();

        sort(data, 0, data.length - 1);
        System.out.println(Arrays.toString(data).replaceAll("[\\[\\],]", ""));
    }
    private static void sort(int[] data, int start, int end) {
        if (start < end) {
            int pIndex = partition(data, start, end);

            // do the same sorting for the elements before the pivot and for the elements after the pivot
            sort(data, 0, pIndex - 1);
            sort(data, pIndex + 1, end);
        }
    }

    private static int partition(int[] data, int start, int end) {
        int pivot = data[end];  // number to compare with
        int pIndex = start;     // partition index

        // arrange members, so that if value is greater than pivot, no action is done,
        // but if number is smaller, than we swap this element with the element located
        // on the pIndex - this is the next index after the last smaller than pivot value.
        for (int i = start; i < end; i++) {
            if (data[i] <= pivot) {
                swap(data, pIndex, i);
                pIndex++;
            }
        }

        // swap pivot with first greater value from the right part
        swap(data, pIndex, end);

        return pIndex;
    }

    private static void swap(int[] data, int pIndex, int i) {
        int temp = data[pIndex];
        data[pIndex] = data[i];
        data[i] = temp;
    }
}
