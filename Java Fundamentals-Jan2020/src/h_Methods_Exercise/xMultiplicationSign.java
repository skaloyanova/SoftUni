package h_Methods_Exercise;

import java.util.Scanner;

public class xMultiplicationSign {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num1 = Integer.parseInt(sc.nextLine());
        int num2 = Integer.parseInt(sc.nextLine());
        int num3 = Integer.parseInt(sc.nextLine());

        printSign(num1, num2, num3);
    }

    private static void printSign(int num1, int num2, int num3) {
        int[] signs = {num1, num2, num3};

        int cntNeg = 0;

        for (int i = 0; i < 3; i++) {
            if (signs[i] == 0) {
                System.out.println("zero");
                return;
            } else if (signs[i] < 0) {
                cntNeg++;
            }
        }

        if (cntNeg == 1 || cntNeg == 3) {
            System.out.println("negative");
        } else {
            System.out.println("positive");
        }
    }
}
