package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class MathPotato {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s+");
        int toss = Integer.parseInt(sc.nextLine());

        Deque<String> names = new ArrayDeque<>(Arrays.asList(input));
        int turn = 1;
        while (names.size() > 1) {
            for (int i = 1; i < toss; i++) {
                String current = names.poll();
                names.offer(current);
            }
            if (isPrime(turn)) {
                String current = names.peek();
                System.out.println("Prime " + current);
            } else {
                System.out.println("Removed " + names.poll());
            }
            turn++;
        }

        System.out.println("Last is " + names.poll());
    }

    private static boolean isPrime(int turn) {
        if (turn == 1) {
            return false;
        }
        for (int i = 2; i < turn; i++) {
            if (turn % i == 0) {
                return false;
            }
        }
        return true;
    }
}
