package Mid2020_02_29_gr2;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class ShoppingList {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<String> products = Arrays.stream(sc.nextLine().split("!")).collect(Collectors.toList());

        String input = sc.nextLine();

        while (!"Go Shopping!".equals(input)) {
            String[] tokens = input.split(" ");

            String action = tokens[0];
            String item = tokens[1];

            switch (action) {
                case "Urgent":
                    if (!products.contains(item)) {
                        products.add(0, item);
                    }
                    break;
                case "Unnecessary":
                    products.remove(item);
                    break;
                case "Correct":
                    String newItem = tokens[2];
                    if (products.contains(item)) {
                        int itemIndex = products.indexOf(item);
                        products.set(itemIndex, newItem);
                    }
                    break;
                case "Rearrange":
                    if (products.contains(item)) {
                        products.remove(item);
                        products.add(item);
                    }
            }
            input = sc.nextLine();
        }

        System.out.println(String.join(", ", products));
    }
}
