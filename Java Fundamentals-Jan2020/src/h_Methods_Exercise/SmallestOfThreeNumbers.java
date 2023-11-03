package h_Methods_Exercise;

import java.util.Scanner;

public class SmallestOfThreeNumbers {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n1 = Integer.parseInt(sc.nextLine());
        int n2 = Integer.parseInt(sc.nextLine());
        int n3 = Integer.parseInt(sc.nextLine());

        printSmallestNumber(n1, n2, n3);
    }

    private static void printSmallestNumber(int n1, int n2, int n3) {
        //int result = Math.min(Math.min(n1, n2), n3);

        int min = n1;
        if (n2 < min) {
            min = n2;
        }
        if (n3 < min) {
            min = n3;
        }

       // System.out.println(result);
        System.out.println(min);
    }
}
