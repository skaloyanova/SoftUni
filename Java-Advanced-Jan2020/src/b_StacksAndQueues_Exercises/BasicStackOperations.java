package b_StacksAndQueues_Exercises;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class BasicStackOperations {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] tokens = readInput(sc);
        int[] numbers = readInput(sc);

        int elementsToPush = tokens[0];
        int elementsToPop = tokens[1];
        int elementToSearch = tokens[2];

        Deque<Integer> stackNumbers = new ArrayDeque<>();
        String output = "";

        //push
        for (int i = 0; i < Math.min(elementsToPush, numbers.length); i++) {
            stackNumbers.push(numbers[i]);
        }
        //pop
        for (int i = 0; i < elementsToPop; i++) {
            stackNumbers.pop();
        }
        int stackSize = stackNumbers.size();

        //search
        int min = Integer.MAX_VALUE;
        while (stackNumbers.size() > 0) {
            int current = stackNumbers.pop();

            if (current == elementToSearch) {
                System.out.println("true");
                return;
            }

            if (current < min) {
                min = current;
            }
        }

        //output
        if (stackSize == 0) {
            System.out.println(0);
        } else {
            System.out.println(min);
        }
    }

    private static int[] readInput(Scanner sc) {
        return Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();
    }
}
