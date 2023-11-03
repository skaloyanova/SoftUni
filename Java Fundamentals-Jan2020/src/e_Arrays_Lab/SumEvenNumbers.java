package e_Arrays_Lab;

import java.util.Scanner;

public class SumEvenNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] inputArr = sc.nextLine().split(" ");
        int length = inputArr.length;

        int[] number = new int[length];

        for (int i = 0; i < length; i++) {
            number[i] = Integer.parseInt(inputArr[i]);
        }

        int sum = 0;
        for (int i = 0; i < length; i++) {
            if (number[i] % 2 == 0) {
                sum += number[i];
            }
        }
        System.out.println(sum);
    }
}
