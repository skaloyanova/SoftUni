package n_AssociativeArrays_Exercise;

import java.util.*;

public class xDragonArmy {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        LinkedHashMap<String, TreeMap<String, List<Integer>>> dragons = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String type = tokens[0];
            String name = tokens[1];

            int damage = 45;
            int health = 250;
            int armor = 10;

            if (!"null".equals(tokens[2])) {
                damage = Integer.parseInt(tokens[2]);
            }
            if (!"null".equals(tokens[3])) {
                health = Integer.parseInt(tokens[3]);
            }
            if (!"null".equals(tokens[4])) {
                armor = Integer.parseInt(tokens[4]);
            }

            dragons.putIfAbsent(type, new TreeMap<>());
            dragons.get(type).putIfAbsent(name, new ArrayList<>());
            dragons.get(type).put(name, Arrays.asList(damage, health, armor));

        }

        dragons
                .entrySet()
                .forEach(d -> {
                    double[] averages = calculateAverage(d.getValue());
                    System.out.println(String.format("%s::(%.2f/%.2f/%.2f)",
                            d.getKey(), averages[0], averages[1], averages[2]));

                    d.getValue()
                            .entrySet()
                            .forEach(e -> {
                                System.out.println(String.format("-%s -> damage: %d, health: %d, armor: %d",
                                        e.getKey(), e.getValue().get(0), e.getValue().get(1), e.getValue().get(2)));
                            });
                });
    }

    private static double[] calculateAverage(TreeMap<String, List<Integer>> map) {
        double totalEntries = map.size();
        int totalDamage = 0;
        int totalHealth = 0;
        int totalArmor = 0;

        for (Map.Entry<String, List<Integer>> entry : map.entrySet()) {
            totalDamage += entry.getValue().get(0);
            totalHealth += entry.getValue().get(1);
            totalArmor += entry.getValue().get(2);
        }

        return new double[] {
                totalDamage / totalEntries,
                totalHealth / totalEntries,
                totalArmor / totalEntries
        };
    }
}
