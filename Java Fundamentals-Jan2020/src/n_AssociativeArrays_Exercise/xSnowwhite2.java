package n_AssociativeArrays_Exercise;

import java.util.*;

public class xSnowwhite2 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        LinkedHashMap<String, Integer> dwarfs = new LinkedHashMap<>();

        String input = sc.nextLine();

        while (!"Once upon a time".equals(input)) {
            String[] tokens = input.split(" <:> ");

            String name = tokens[0];
            String hatColor = tokens[1];

            String nameAndHat = name + " " + hatColor;
            int physics = Integer.parseInt(tokens[2]);

            dwarfs.putIfAbsent(nameAndHat, 0);
            dwarfs.put(nameAndHat, Math.max(dwarfs.get(nameAndHat),physics));


            input = sc.nextLine();
        }

        //Print
        List<String> hats = new ArrayList<>();
        dwarfs.forEach((key, value) -> hats.add(key.split(" ")[1]));

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
                        Integer p1Cnt = hatsCnt.get(p1.getKey().split(" ")[1]);
                        Integer p2Cnt = hatsCnt.get(p2.getKey().split(" ")[1]);
                        res = p2Cnt.compareTo(p1Cnt);
                    }
                    return res;
                })
                .forEach(d -> {
                    String name = d.getKey().split(" ")[0];
                    String color = d.getKey().split(" ")[1];
                    int physics = d.getValue();
                    System.out.println(String.format("(%s) %s <-> %d", color, name, physics));
                });
    }
}
