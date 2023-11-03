package n_AssociativeArrays_Exercise;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class LegendaryFarming {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> items = new HashMap<>() {{
            put("fragments", 0); put("shards", 0); put("motes", 0);
        }};

        Map<String, Integer> junk = new TreeMap<>();

        boolean isLegendary = false;
        while (!isLegendary) {
            String[] tokens = sc.nextLine().toLowerCase().split("\\s+");

            for (int i = 0; i < tokens.length; i += 2) {
                String material = tokens[i + 1];
                int count = Integer.parseInt(tokens[i]);

                if (items.containsKey(material)) {
                    addItem(items, material, count);
                    isLegendary = hasItem(items, material);
                    if (isLegendary) {
                        break;
                    }

                } else {
                    addItem(junk, material, count);
                }
            }
        }

        //legendary found
        items.entrySet().stream()
                .sorted((e1, e2) -> {
                    int res = e2.getValue().compareTo(e1.getValue());
                    if (res == 0) {
                        res = e1.getKey().compareTo(e2.getKey());
                    }
                    return res;
                })
                .forEach(e -> System.out.println(String.format("%s: %d", e.getKey(), e.getValue())));

        junk.forEach((key, value) -> System.out.println(String.format("%s: %d", key, value)));
    }

    private static boolean hasItem(Map<String, Integer> items, String material) {
        int count = items.get(material);

        if (count >= 250) {
            items.put(material, count - 250);
            switch (material) {
                case "shards": System.out.println("Shadowmourne obtained!"); return true;
                case "fragments": System.out.println("Valanyr obtained!"); return true;
                case "motes": System.out.println("Dragonwrath obtained!"); return true;
            }
        }
        return false;
    }

    private static void addItem(Map<String, Integer> map, String key, int value) {
        map.putIfAbsent(key, 0);
        int count = map.get(key);
        map.put(key, count + value);
    }
}
