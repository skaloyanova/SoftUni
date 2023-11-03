package e_Arrays_Lab;

import java.util.Arrays;
import java.util.Scanner;

public class EqualArrays {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] arr1 = Arrays
                .stream(sc.nextLine().split(" "))
                .mapToInt(e -> Integer.parseInt(e))
                .toArray();

        int[] arr2 = Arrays
                .stream(sc.nextLine().split(" "))
                .mapToInt(e -> Integer.parseInt(e))
                .toArray();

        int sum = 0;
        boolean isDiff = false;
        String diff = "";

        for (int i = 0; i < arr1.length; i++) {
            if (arr1[i] == arr2[i]) {
                sum += arr1[i];
            } else {
                diff = String.format("Arrays are not identical. Found difference at %d index.", i);
                isDiff = true;
                break;
            }
        }
        if (isDiff) {
            System.out.println(diff);
        } else {
            System.out.println(String.format("Arrays are identical. Sum: %d", sum));
        }
    }
}
