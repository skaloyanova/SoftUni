package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class DecimalToBinaryConverter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int decimal = Integer.parseInt(sc.nextLine());

        Deque<Integer> binary = new ArrayDeque<>();

        int absDecimal = Math.abs(decimal);
        while (absDecimal > 0) {
            binary.push(absDecimal % 2);
            absDecimal = absDecimal / 2;
        }

        if (decimal == 0) {
            System.out.println(0);
        }
        if (decimal < 0) {
            System.out.print("-");
        }
        System.out.println(binary.toString().replaceAll("[\\[\\], ]", ""));
//        binary.forEach(System.out::print);
    }
}
