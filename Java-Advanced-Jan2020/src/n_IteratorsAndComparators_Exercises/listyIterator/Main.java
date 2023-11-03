package n_IteratorsAndComparators_Exercises.listyIterator;

import java.util.NoSuchElementException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ListyIterator data = new ListyIterator();

        String line = sc.nextLine();
        while (!"END".equals(line)) {
            String[] tokens = line.split("\\s+");

            String command = tokens[0];
            switch (command) {
                case "Create":
                    String[] elements = new String[tokens.length - 1];
                    System.arraycopy(tokens, 1, elements, 0, tokens.length - 1);
                    data.create(elements);
                    break;
                case "Move":
                    System.out.println(data.move());
                    break;
                case "Print":
                    try {
                        System.out.println(data.print());
                    } catch (NoSuchElementException e) {
                        System.out.println(e.getMessage());
                    }
                    break;
                case "HasNext":
                    System.out.println(data.hasNext());
                    break;
                case "PrintAll":
                    try {
                        System.out.println(data.PrintAll());
                    } catch (NoSuchElementException e) {
                        System.out.println(e.getMessage());
                    }
                    break;
            }

            line = sc.nextLine();
        }
    }
}
