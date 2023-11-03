package f_Arrays_Exercise;

import java.util.Scanner;

public class ArrayRotation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] originalArr = sc.nextLine().split(" ");
        int n = Integer.parseInt(sc.nextLine());

        String[] rotatedArr = new String[originalArr.length];

        int startIndex = n % originalArr.length;
        int index = 0;

        for (int i = 0; i < rotatedArr.length; i++) {
            if (startIndex < rotatedArr.length) {
                rotatedArr[i] = originalArr[startIndex++];
            } else {
                rotatedArr[i] = originalArr[index++];
            }
        }
        System.out.println(String.join(" ", rotatedArr));

//        int rotation = n % originalArr.length;
//
//        for (int i = 0; i < rotation; i++) {
//            String temp = originalArr[0];
//            for (int j = 0; j < originalArr.length - 1; j++) {
//                originalArr[j] = originalArr[j + 1];
//            }
//            originalArr[originalArr.length - 1] = temp;
//        }
//        System.out.println(String.join(" ", originalArr));
    }
}
