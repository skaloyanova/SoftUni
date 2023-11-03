package f_SetsAndMapsAdvanced_Exercises;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class LegendaryFarming {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> keyItems = new TreeMap<>() {{
            put("shards", 0); put("motes", 0); put("fragments", 0);
        }};
        Map<String, Integer> junkItems = new TreeMap<>();

        boolean gotLegendary = false;
        while (!gotLegendary) {
            String[] line = sc.nextLine().toLowerCase().split("\\s+");
            for (int i = 0; i < line.length; i++) {
                int quantity = Integer.parseInt(line[i]);
                String material = line[++i];

                switch (material) {
                    case "shards":
                    case "fragments":
                    case "motes":
                        keyItems.put(material, keyItems.get(material) + quantity);

                        if (keyItems.get(material) >= 250) {
                            gotLegendary = true;
                        }
                        break;
                    default:
                        junkItems.putIfAbsent(material, 0);
                        junkItems.put(material, junkItems.get(material) + quantity);
                        break;
                }
                if (gotLegendary) {
                    keyItems.put(material, keyItems.get(material) - 250);
                    legendaryObtainedPrint(material);
                    break;
                }
            }
        }

        //print
        keyItems.entrySet()
                .stream()
                .sorted((a1,a2) -> a2.getValue().compareTo(a1.getValue()))
                .forEach(e -> System.out.println(e.getKey() + ": " + e.getValue()));

        junkItems.forEach((k,v) -> System.out.println(k + ": " + v));

    }

    private static void legendaryObtainedPrint(String material) {
        switch (material) {
            case "shards": System.out.println("Shadowmourne obtained!"); break;
            case "fragments": System.out.println("Valanyr obtained!"); break;
            case "motes": System.out.println("Dragonwrath obtained!"); break;
        }
    }
}

