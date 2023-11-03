package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class EvenNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n;
        while (true) {
            n = Integer.parseInt(sc.nextLine());
            if (n % 2 != 0) {
                System.out.println("Please write an even number.");
            } else {
                System.out.println("The number is: " + Math.abs(n));
                break;
            }
        }
    }
}
