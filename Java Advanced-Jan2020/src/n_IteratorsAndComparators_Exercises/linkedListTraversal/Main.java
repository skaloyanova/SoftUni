package n_IteratorsAndComparators_Exercises.linkedListTraversal;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        MyLinkedList<Integer> list = new MyLinkedList<>();

        int n = Integer.parseInt(sc.nextLine());

        while (n-- > 0) {
            String[] tokens = sc.nextLine().split("\\s+");

            String action = tokens[0];
            int element = Integer.parseInt(tokens[1]);

            if ("Add".equals(action)) {
                list.add(element);
            } else if ("Remove".equals(action)) {
                list.remove(element);
            }
        }

        System.out.println(list.getSize());
        list.forEach(e -> System.out.print(e + " "));

    }
}
