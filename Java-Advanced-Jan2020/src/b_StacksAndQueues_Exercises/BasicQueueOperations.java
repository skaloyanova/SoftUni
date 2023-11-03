package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class BasicQueueOperations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int elementsToEnqueue = sc.nextInt();
        int elementsToDequeue = sc.nextInt();
        int elementToSearch = sc.nextInt();

        //read the extra symbol after nextInt
        sc.nextLine();

        ArrayDeque<Integer> queue = new ArrayDeque<>();

        int[] input = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        //offer
        for (int i = 0; i < elementsToEnqueue; i++) {
            queue.offer(input[i]);
        }

        //poll
        for (int i = 0; i < elementsToDequeue; i++) {
            queue.poll();
        }

        //search
        if (queue.contains(elementToSearch)) {
            System.out.println("true");
        } else {
            //var1
            System.out.println(queue.stream().min(Integer::compareTo).orElse(0));
            //var2
//            if (!queue.isEmpty()) {
//                System.out.println(Collections.min(queue));
//            } else {
//                System.out.println(0);
//            }
        }

    }
}

