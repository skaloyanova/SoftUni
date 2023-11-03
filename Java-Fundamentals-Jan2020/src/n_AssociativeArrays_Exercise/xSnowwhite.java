// One of the sorting at print out is not done !!
// Judge 50/100
package n_AssociativeArrays_Exercise;

import java.util.*;

public class xSnowwhite {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        LinkedHashMap<Map<String, String>, Integer> dwarfs = new LinkedHashMap<>();
        LinkedHashMap<String, Integer> colorCnt = new LinkedHashMap<>();


        String input = sc.nextLine();

        while (!"Once upon a time".equals(input)) {
            String[] tokens = input.split(" <:> ");

            String name = tokens[0];
            String hatColor = tokens[1];
            int physics = Integer.parseInt(tokens[2]);


            Map<String, String> dwarfsNameHatMap = new LinkedHashMap<>();
            dwarfsNameHatMap.putIfAbsent(name, "");
            dwarfsNameHatMap.put(name, hatColor);
            dwarfs.putIfAbsent(dwarfsNameHatMap, 0);
            dwarfs.put(dwarfsNameHatMap, physics);

            colorCnt.putIfAbsent(hatColor, 0);
            colorCnt.put(hatColor, colorCnt.get(hatColor) + 1);

            input = sc.nextLine();
        }

        //Print
        List<String> hats = new ArrayList<>();
        dwarfs.entrySet().forEach(e -> hats.add(e.getKey().values().toString()));

        Map<String, Integer> hatsCnt = new HashMap<>();
        for (String hat : hats) {
            hatsCnt.putIfAbsent(hat, 0);
            hatsCnt.put(hat, hatsCnt.get(hat) + 1);
        }

        dwarfs.entrySet()
                .stream()
                .sorted((p1, p2) -> {
                    int res = p2.getValue().compareTo(p1.getValue());
                    if (res == 0) {
                        //todo - sort by hatColor count
                    }
                    return res;
                })
                .forEach(d -> {
                    String color = d.getKey().values().toString().replaceAll("[\\[\\]]", "");
                    String name = d.getKey().keySet().toString().replaceAll("[\\[\\]]", "");
                    int physics = d.getValue();
                    System.out.println(String.format("(%s) %s <-> %d", color, name, physics));
                });
    }
}
