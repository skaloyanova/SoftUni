package q_BasicAlgorithms_Lab;

import java.util.Scanner;

public class BinarySearch {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

//        int[] data = Arrays.stream(sc.nextLine().split("\\s+")).mapToInt(Integer::parseInt).toArray();
//        int number = Integer.parseInt(sc.nextLine());

        int[] data = {1, 2, 5, 7, 12, 46, 78, 80};
        int number = 1;

        int index = returnIndex(data, number);
        int indexWithRecursion = returnIndexRecursively(data, number, 0, data.length - 1);

        System.out.println(index);
        System.out.println(indexWithRecursion);
    }

    private static int returnIndexRecursively(int[] data, int number, int start, int end) {
        if (start > end) {
            return -1;
        }

        int mid = (start + end) / 2;

        if (number == data[mid]) {
            return mid;
        }
        if (number > data[mid]) {
            return returnIndexRecursively(data, number, mid + 1, end);
        } else {
            return returnIndexRecursively(data, number, start, mid - 1);
        }
    }

    private static int returnIndex(int[] data, int number) {
        if (number > data[data.length - 1] || number < data[0]) {
            return -1;
        }
        int startIdx = 0;
        int endIdx = data.length - 1;

        while (startIdx <= endIdx) {
            //var 1 for defining midIdx
//            int midIdx = startIdx + (endIdx - startIdx) / 2;

            //var 2 for defining midIdx (same equation as above)
            int midIdx = (startIdx + endIdx) / 2;

            int midElement = data[midIdx];

            if (number == midElement) {
                return midIdx;
            }

            if (number > midElement) {
                startIdx = midIdx + 1;
            } else {
                endIdx = midIdx - 1;
            }
        }
        return -1;
    }
}
