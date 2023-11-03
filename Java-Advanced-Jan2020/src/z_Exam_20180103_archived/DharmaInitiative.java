package z_Exam_20180103_archived;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class DharmaInitiative {

    public static void main(String[] args) {
        Map<String, String> stations = new TreeMap<>() {{
            put("Hydra", "The Hydra station: Zoological Research.");
            put("Arrow", "The Arrow station: Development of defensive strategies, and Intelligence gathering.");
            put("Flame", "The Flame station: Communication.");
            put("Pearl", "The Pearl station: Psychological Research and/or Observation.");
            put("Orchid", "The Orchid station: Space-time manipulation research, disguised as a Botanical station.");
        }};

        Map<String, Map<String, Integer>> recruits = new TreeMap<>() {{
            put("Hydra", new HashMap<>());
            put("Arrow", new HashMap<>());
            put("Flame", new HashMap<>());
            put("Pearl", new HashMap<>());
            put("Orchid", new HashMap<>());
        }};

        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();

        while (!"Recruit".equals(input)) {
            String[] tokens = input.split(":");

            String person = tokens[0];
            int facilityNum = Integer.parseInt(tokens[1]);
            String station = tokens[2];

            if (recruits.containsKey(station)) {
                recruits.get(station).put(person, facilityNum);
            }

            input = sc.nextLine();
        }

        String command = sc.nextLine();

        if ("DHARMA Initiative".equals(command)) {
            recruits.entrySet().stream()
                    .sorted((e1, e2) -> Integer.compare(e2.getValue().size(), e1.getValue().size()))
                    .forEach(e -> System.out.printf("The %s has %d DHARMA recruits in it.%n",
                            e.getKey(), e.getValue().size()));
        } else if (!stations.containsKey(command)) {
            System.out.println("DHARMA Initiative does not have such a station!");
        } else {
            System.out.println(stations.get(command));

            if (recruits.get(command).values().size() == 0) {
                System.out.println("No recruits.");
            } else {
                recruits.get(command).entrySet().stream()
                        .sorted((e1, e2) -> Integer.compare(e2.getValue(), e1.getValue()))
                        .forEach(e -> System.out.printf("###%s - %d%n", e.getKey(), e.getValue()));
            }
        }
    }
}
