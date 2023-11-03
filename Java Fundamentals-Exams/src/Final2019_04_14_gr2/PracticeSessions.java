package Final2019_04_14_gr2;

import java.util.*;

public class PracticeSessions {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, List<String>> roads = new TreeMap<>();

        String input = sc.nextLine();
        while (!"END".equals(input)) {
            String[] tokens = input.split("->");

            switch (tokens[0]) {
                case "Add": {
                    String road = tokens[1];
                    String racer = tokens[2];
                    roads.putIfAbsent(road, new ArrayList<>());
                    roads.get(road).add(racer);
                }
                    break;
                case "Move": {
                    String currentRoad = tokens[1];
                    String racer = tokens[2];
                    String nextRoad = tokens[3];

                    if (roads.get(currentRoad).contains(racer)) {
                        roads.get(currentRoad).remove(racer);
                        roads.get(nextRoad).add(racer);
                    }
                }
                    break;
                case "Close": {
                    String road = tokens[1];
                    roads.remove(road);
                }
                    break;
            }
            input = sc.nextLine();
        }
        //output
        System.out.println("Practice sessions:");
        roads.entrySet()
                .stream()
                .sorted((r1,r2) -> r2.getValue().size() - r1.getValue().size())
                .forEach(e -> {
                    System.out.println(e.getKey());
                    e.getValue().forEach(r -> System.out.println("++" + r));
                });
    }
}
