package f_SetsAndMapsAdvanced_Exercises;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class PopulationCounter {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,Map<String,Integer>> data = new LinkedHashMap<>();
        // <country <town, population>>

        String line = sc.nextLine();
        while (!"report".equals(line)) {
            String[] tokens = line.split("\\|");
            String town = tokens[0];
            String country = tokens[1];
            int population = Integer.parseInt(tokens[2]);

            data.putIfAbsent(country, new LinkedHashMap<>());
            data.get(country).put(town,population);

            line = sc.nextLine();
        }
        data.entrySet()
                .stream()
                .sorted((p1,p2) -> {
                    Long sum1 = p1.getValue().values().stream().mapToLong(x -> x).sum();
                    Long sum2 = p2.getValue().values().stream().mapToLong(x -> x).sum();
                    return sum2.compareTo(sum1);
                })
                .forEach(e -> {
                    long sum = e.getValue().values().stream().mapToLong(x -> x).sum();
                    System.out.println(String.format("%s (total population: %d)", e.getKey(), sum));
                    e.getValue().entrySet()
                            .stream()
                            .sorted((p1,p2) -> p2.getValue().compareTo(p1.getValue()))
                            .forEach(t -> System.out.println(String.format("=>%s: %d",t.getKey(),t.getValue())));
                });
    }
}
