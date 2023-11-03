package n_AssociativeArrays_Exercise;

import java.util.*;

public class xRanking {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,String> contests = new HashMap<>();
        Map<String, Map<String,Integer>> submissions = new TreeMap<>();

        //add contests
        String input = sc.nextLine();
        while (!"end of contests".equals(input)) {
            String[] tokens = input.split(":");

            String contest = tokens[0];
            String pass = tokens[1];

            contests.putIfAbsent(contest, "");
            contests.put(contest, pass);

            input = sc.nextLine();
        }

        //add submissions
        input = sc.nextLine();
        while (!"end of submissions".equals(input)) {
            String[] tokens = input.split("=>");

            String contest = tokens[0];
            String password = tokens[1];
            String username = tokens[2];
            int points = Integer.parseInt(tokens[3]);

            if (!password.equals(contests.get(contest))) {
                input = sc.nextLine();
                continue;
            }

            submissions.putIfAbsent(username, new HashMap<>());
            submissions.get(username).putIfAbsent(contest, 0);
            int current = submissions.get(username).get(contest);
            submissions.get(username).put(contest, Math.max(points, current));

            input = sc.nextLine();
        }

        //output
        int maxSum = 0;
        String bestCandidate = "";
        for (Map.Entry<String, Map<String, Integer>> entry : submissions.entrySet()) {
            int sum = entry.getValue().values().stream().mapToInt(x -> x).sum();
            if (sum > maxSum) {
                maxSum = sum;
                bestCandidate = entry.getKey();
            }
        }

        System.out.println(String.format("Best candidate is %s with total %d points.", bestCandidate,maxSum));

        System.out.println("Ranking: ");
        submissions.forEach((k,v) -> {
            System.out.println(k);
            v.entrySet()
                    .stream()
                    .sorted((p1,p2) -> p2.getValue().compareTo(p1.getValue()))
                    .forEach(e -> System.out.println(String.format("#  %s -> %d", e.getKey(),e.getValue())));
        });

    }
}
