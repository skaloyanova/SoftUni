package MidRetake2019_08_06;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class TreasureHunt {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] lootArr = sc.nextLine().split("\\|");
        List <String> lootList = new ArrayList<>(Arrays.asList(lootArr));

        while (true) {
            String command = sc.nextLine();
            if ("Yohoho!".equals(command)) {
                break;
            }

            String[] tokens = command.split("\\s+");

            switch (tokens[0]) {
                case "Loot":
                    for (int i = 1; i < tokens.length; i++) {
                        if (!lootList.contains(tokens[i])) {
                            lootList.add(0, tokens[i]);
                        }
                    }
                    break;
                case "Drop":
                    int index = Integer.parseInt(tokens[1]);
                    if (index >=0 && index < lootList.size()) {
                        lootList.add(lootList.remove(index));
                    }
                    break;
                case "Steal":
                    int count = Integer.parseInt(tokens[1]);
                    int startIndex = lootList.size() - count;
                    if (startIndex < 0) {
                        startIndex = 0;
                    }
                    List<String> removedLoot = new ArrayList<>();

                    // Var2 with stream
//                    int min = Math.min(count, lootList.size());
//                    List<String> removedLoot = lootList.stream().skip(lootList.size() - min).collect(Collectors.toList());
//                    lootList = lootList.stream().limit(lootList.size() - min).collect(Collectors.toList());

                    while (startIndex < lootList.size()) {
                        removedLoot.add(lootList.remove(startIndex));
                    }
                    System.out.println(String.join(", ", removedLoot));
                    break;
            }
        }

        if (lootList.size() == 0) {
            System.out.println("Failed treasure hunt.");
        } else {
            String lootAtOne = String.join("", lootList);
            double avgLootLength = lootAtOne.length() * 1.0 / lootList.size();
            System.out.printf("Average treasure gain: %.2f pirate credits.", avgLootLength);
        }

    }
}
