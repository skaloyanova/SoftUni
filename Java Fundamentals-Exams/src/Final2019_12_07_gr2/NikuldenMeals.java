package Final2019_12_07_gr2;

import java.util.*;

public class NikuldenMeals {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String command = sc.nextLine();

        int unlikeCnt = 0;

        Map<String, List<String>> guests = new LinkedHashMap<>();

        while (!"Stop".equals(command)) {
            String[] tokens = command.split("-");
            String action = tokens[0];
            String guestName = tokens[1];
            String mealName = tokens[2];

            switch (action) {
                case "Like":
                    addToLiked(guests, guestName, mealName);
                    break;
                case "Unlike":
                    if (isRemoveSuccessful(guests, guestName, mealName)) {
                        unlikeCnt++;
                    }
                    break;
            }

            command = sc.nextLine();
        }

        guests.entrySet()
                .stream()
                .sorted((m1, m2) -> {
                    int res = Integer.compare(m2.getValue().size(), m1.getValue().size());
                    if (res == 0) {
                        res = m1.getKey().compareTo(m2.getKey());
                    }
                    return res;
                })
                .forEach(g -> System.out.println(String.format("%s: %s",
                        g.getKey(), String.join(", ", g.getValue()))));


        System.out.println("Unliked meals: " + unlikeCnt);
    }

    private static void addToLiked(Map<String, List<String>> guests, String name, String meal) {
        guests.putIfAbsent(name, new ArrayList<>());
        if (!guests.get(name).contains(meal)) {
            guests.get(name).add(meal);
        }
    }

    private static boolean isRemoveSuccessful(Map<String, List<String>> guests, String name, String meal) {
        if (!guests.containsKey(name)) {
            System.out.println(name + " is not at the party.");
            return false;
        } else if (!guests.get(name).contains(meal)) {
            System.out.println(String.format("%s doesn't have the %s in his/her collection.", name, meal));
            return false;
        } else {
            guests.get(name).remove(meal);
            System.out.println(String.format("%s doesn't like the %s.", name, meal));
            return true;
        }
    }
}

