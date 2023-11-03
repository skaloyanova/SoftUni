package a_StacksAndQueues_Lab;

import java.util.ArrayDeque;
import java.util.Collections;
import java.util.Deque;
import java.util.Scanner;

public class HotPotato {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] namesArr = sc.nextLine().split("\\s+");
        int n = Integer.parseInt(sc.nextLine());

        Deque<String> names = new ArrayDeque<>();

        Collections.addAll(names, namesArr);

        while (names.size() > 1) {
            for (int i = 1; i < n; i++) {
                names.offer(names.poll());
            }
            System.out.println("Removed " + names.poll());
        }
        System.out.println("Last is " + names.poll());
    }
}
