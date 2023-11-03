package Mid2020_02_29_gr1;

import java.util.*;

public class Inventory {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] inventoryArr = sc.nextLine().split(", ");
        List<String> inventory = new ArrayList<>(Arrays.asList(inventoryArr));

        String input = sc.nextLine();

        while (!"Craft!".equals(input)) {
            String[] tokens = input.split(" - ");

            String action = tokens[0];
            String item = tokens[1];

            switch (action) {
                case "Collect":
                    if (!inventory.contains(item)) {
                        inventory.add(item);
                    }
                    break;
                case "Drop":
                    inventory.remove(item);
                    break;
                case "Combine Items":
                    String[] oldNewItem = item.split(":");

                    if (!inventory.contains(oldNewItem[0])) {
                        break;
                    }
                    int oldItemIndex = inventory.indexOf(oldNewItem[0]);
                    inventory.add(oldItemIndex + 1, oldNewItem[1]);
                    break;
                case "Renew":
                    if (inventory.contains(item)) {
                        inventory.remove(item);
                        inventory.add(item);
                    }
                    break;
            }

            input = sc.nextLine();
        }

        //output
        System.out.println(String.join(", ", inventory));
    }
}
