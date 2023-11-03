package Final2020_04_04_gr1;

import java.util.*;

public class Pirates {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, List<Integer>> cities = new HashMap<>();
        String input = sc.nextLine();

        while (!"Sail".equals(input)) {
            String[] tokens = input.split("\\|\\|");
            String city = tokens[0];
            int population = Integer.parseInt(tokens[1].trim());
            int gold = Integer.parseInt(tokens[2].trim());

            if (cities.containsKey(city)) {
                int currentPop = cities.get(city).get(0);
                int currentGold = cities.get(city).get(1);
                cities.get(city).set(0, currentPop + population);
                cities.get(city).set(1, currentGold + gold);
            } else {
                cities.put(city, new ArrayList<>());
                cities.get(city).add(0, population);
                cities.get(city).add(1, gold);
            }
            input = sc.nextLine();
        }

        input = sc.nextLine();
        while (!"End".equals(input)) {
            String[] tokens = input.split("=>");
            String action = tokens[0];
            String city = tokens[1];

            switch (action) {
                case "Plunder":
                    int people = Integer.parseInt(tokens[2].trim());
                    int gold = Integer.parseInt(tokens[3].trim());

                    int newPeople = cities.get(city).get(0) - people;
                    int newGold = cities.get(city).get(1) - gold;

                    cities.get(city).set(0,newPeople);
                    cities.get(city).set(1, newGold);

                    System.out.println(String.format("%s plundered! %d gold stolen, %d citizens killed.",
                            city, gold, people));

                    if (newGold <= 0 || newPeople <= 0) {
                        cities.remove(city);
                        System.out.println(city + " has been wiped off the map!");
                    }
                    break;

                case "Prosper":
                    int goldAdd = Integer.parseInt(tokens[2]);
                    if (goldAdd < 0) {
                        System.out.println("Gold added cannot be a negative number!");
                        break;
                    }
                    int currentGold = cities.get(city).get(1);
                    cities.get(city).set(1, currentGold + goldAdd);
                    System.out.println(String.format("%s gold added to the city treasury. %s now has %d gold.",
                            goldAdd, city, (currentGold + goldAdd)));
                    break;
            }

            input = sc.nextLine();
        }

        System.out.printf("Ahoy, Captain! There are %d wealthy settlements to go to:%n", cities.size());
        if (cities.size() == 0) {
            System.out.println("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
        cities.entrySet()
                .stream()
                .sorted((c1,c2) -> {
                    int res = c2.getValue().get(1).compareTo(c1.getValue().get(1));
                    if (res == 0) {
                        res = c1.getKey().compareTo(c2.getKey());
                    }
                    return res;
                })
                .forEach(e -> System.out.println(String.format("%s -> Population: %d citizens, Gold: %d kg",
                        e.getKey(),e.getValue().get(0), e.getValue().get(1))));
    }
}
