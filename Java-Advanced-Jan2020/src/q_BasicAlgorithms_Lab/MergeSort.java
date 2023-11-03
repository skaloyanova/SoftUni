package q_BasicAlgorithms_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class MergeSort {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

//        int[] one = {1, 10, 14, 20};
//        int[] two = {4, 17, 18, 25, 78, 80};
//
//        System.out.println(Arrays.toString(mergeTwoSortedArrays(one, two)));

        int[] arr = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
        System.out.println(Arrays.toString(mergeSort(arr)).replaceAll("[\\[\\],]", ""));
    }

    private static int[] mergeSort(int[] array) {
        if (array.length == 1) {
            return array;
        }
        int lengthFirst = array.length / 2;
        int lengthSecond = array.length - lengthFirst;

        int[] firstArr = new int[lengthFirst];
        int[] secondArr = new int[lengthSecond];

        System.arraycopy(array, 0, firstArr, 0, lengthFirst);
        System.arraycopy(array, lengthFirst, secondArr, 0, lengthSecond);

        firstArr = mergeSort(firstArr);
        secondArr = mergeSort(secondArr);

        return mergeTwoSortedArrays(firstArr, secondArr);
    }

    private static int[] mergeTwoSortedArrays(int[] firstArr, int[] secondArr) {
        int[] mergedArray = new int[firstArr.length + secondArr.length];

        int indexFirst = 0;
        int indexSecond = 0;

        while (indexFirst < firstArr.length && indexSecond < secondArr.length) {
            if (firstArr[indexFirst] < secondArr[indexSecond]) {
                mergedArray[indexFirst + indexSecond] = firstArr[indexFirst];
                indexFirst++;
            } else {
                mergedArray[indexFirst + indexSecond] = secondArr[indexSecond];
                indexSecond++;
            }
        }

        while (indexFirst < firstArr.length) {
            mergedArray[indexFirst + indexSecond] = firstArr[indexFirst];
            indexFirst++;
        }

        while (indexSecond < secondArr.length) {
            mergedArray[indexFirst + indexSecond] = secondArr[indexSecond];
            indexSecond++;
        }

        return mergedArray;
    }
}
