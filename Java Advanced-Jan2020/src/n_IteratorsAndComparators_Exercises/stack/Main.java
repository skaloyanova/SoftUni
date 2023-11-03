package n_IteratorsAndComparators_Exercises.stack;

import java.util.Arrays;
import java.util.NoSuchElementException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Stack intStack = new Stack();

        String input = sc.nextLine().trim();
        while (!"END".equals(input)) {
            String[] tokens = input.split("[, ]+");

            if ("Push".equals(tokens[0])) {
//                int[] elements = Arrays.stream(tokens).skip(1).mapToInt(Integer::parseInt).toArray();
//                intStack.push(elements);
                Arrays.stream(tokens).skip(1).mapToInt(Integer::parseInt).forEach(intStack::push);

            } else if ("Pop".equals(tokens[0])) {
                try {
                    intStack.pop();
                } catch (NoSuchElementException e) {
                    System.out.println(e.getMessage());
                }
            }

            input = sc.nextLine();
        }

        //print
        for (Integer integer : intStack) {
            System.out.println(integer);
        }
        for (Integer integer : intStack) {
            System.out.println(integer);
        }
    }
}
