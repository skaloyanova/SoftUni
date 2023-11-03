package f_Arrays_Exercise;

import java.util.Scanner;

public class ZigZagArrays {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        String[] arr1 = new String[n];
        String[] arr2 = new String[n];

        int index = 0;

        for (int i = 1; i <= n; i++) {
            String[] rowString = sc.nextLine().split(" ");

            if (i % 2 == 0) {
                arr2[index] = rowString[0];
                arr1[index] = rowString[1];
            } else {
                arr1[index] = rowString[0];
                arr2[index] = rowString[1];
            }
            index++;
        }

        System.out.println(String.join(" ", arr1));
        System.out.println(String.join(" ", arr2));
    }
}
