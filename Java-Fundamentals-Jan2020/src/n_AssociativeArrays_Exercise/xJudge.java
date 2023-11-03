package n_AssociativeArrays_Exercise;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class xJudge {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        LinkedHashMap<String, LinkedHashMap<String, Integer>> contests = new LinkedHashMap<>();
        Map<String, Integer> maxPoints = new TreeMap<>();

        String input = sc.nextLine();

        while (!"no more time".equals(input)) {
            String[] tokens = input.split(" -> ");

            String user = tokens[0];
            String contest = tokens[1];
            int points = Integer.parseInt(tokens[2]);

            contests.putIfAbsent(contest, new LinkedHashMap<>());
            contests.get(contest).putIfAbsent(user, 0);
            contests.get(contest).put(user, Math.max(points, contests.get(contest).get(user)));


            input = sc.nextLine();
        }
        //sum points for each user and save them in Map totalPoints
        for (LinkedHashMap<String, Integer> entry : contests.values()) {
            entry.forEach((u, p) -> {
                maxPoints.putIfAbsent(u, 0);
                maxPoints.put(u, maxPoints.get(u) + p);
            });
        }

        //print per contests
        contests.forEach((key, value) -> {
            System.out.println(String.format("%s: %d participants", key, value.size()));
            final int[] num1 = {0};
            value
                    .entrySet()
                    .stream()
                    .sorted((a1, a2) -> {
                        int res = Integer.compare(a2.getValue(), a1.getValue());
                        if (res == 0) {
                            res = a1.getKey().compareTo(a2.getKey());
                        }
                        return res;
                    })
                    .forEach(u -> System.out.println(String.format("%d. %s <::> %d", ++num1[0], u.getKey(), u.getValue())));
        });

        //print max points
        final int[] num = {0};
        System.out.println("Individual standings:");
        maxPoints.entrySet()
                .stream()
                .sorted((p1, p2) -> Integer.compare(p2.getValue(), p1.getValue()))
                .forEach(e -> System.out.println(String.format("%d. %s -> %d", ++num[0], e.getKey(), e.getValue())));
    }
}
