package e_SetsAndMapsAdvanced_Lab;

import java.util.*;

public class CitiesByContinentAndCountry {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String, Map<String, List<String>>> geo = new LinkedHashMap<>();

        int n = Integer.parseInt(sc.nextLine());
        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String continent = tokens[0];
            String country = tokens[1];
            String city = tokens[2];

            geo.putIfAbsent(continent, new LinkedHashMap<>());
            geo.get(continent).putIfAbsent(country, new ArrayList<>());
            geo.get(continent).get(country).add(city);
        }
        geo.forEach((k,v) -> {
            System.out.println(k + ":");
            v.forEach((co,ci) -> System.out.printf("  %s -> %s%n",
                    co, ci.toString().replaceAll("[\\[\\]]", "")));
        });
    }
}
