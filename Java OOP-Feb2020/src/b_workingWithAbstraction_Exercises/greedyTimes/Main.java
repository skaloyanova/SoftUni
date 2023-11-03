package b_workingWithAbstraction_Exercises.greedyTimes;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        long capacity = Long.parseLong(scanner.nextLine());
        Treasure treasure = new Treasure(scanner.nextLine().split("\\s+"));

        Bag bag = new Bag(capacity);

        for (Treasure.Pair<String, Long> pair : treasure) {
            String item = pair.getFirst();
            Long amount = pair.getSecond();

            if (!bag.hasEnoughCapacity(amount)) {
                continue;
            }

            String type = "";
            if (item.length() == 3) {
                type = "Cash";
            } else if (item.toLowerCase().endsWith("gem")) {
                type = "Gem";
            } else if (item.toLowerCase().equals("gold")) {
                type = "Gold";
            } else {
                continue;
            }

            bag.add(type, item, amount);
        }

        System.out.println(bag);
    }
}

