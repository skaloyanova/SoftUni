package j_Lists_Exercise;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ChangeList {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] inputArr = sc.nextLine().split("\\s+");
        ArrayList<String> numbers = new ArrayList<>(Arrays.asList(inputArr));

        while (true) {
            String input = sc.nextLine();
            if (input.equalsIgnoreCase("end")) {
                break;
            }

            String[] tokens = input.split("\\s+");
            String action = tokens[0];
            String element = tokens[1];

            if (action.equalsIgnoreCase("delete")) {
                //numbers.removeIf(num -> num == element);
                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i).equals(element)) {
                        numbers.remove(i--);
                    }
                }
            }
            if (action.equalsIgnoreCase("insert")) {
                int index = Integer.parseInt(tokens[2]);
                if (index >= 0 && index < numbers.size()) {
                    numbers.add(index, element);
                }
            }
        }

        System.out.println(String.join(" ", numbers));
    }
}
