package n_AssociativeArrays_Exercise;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class SoftUniExamResults {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Integer> submissions = new TreeMap<>();     //tech, count of submissions
        Map<String, Integer> userPoints = new TreeMap<>();      //username, points

        String input = sc.nextLine();
        while (!"exam finished".equals(input)) {
            String[] tokens = input.split("-");

            String user = tokens[0];
            String tech = tokens[1];

            if ("banned".equals(tech)) {
                userPoints.remove(user);
                input = sc.nextLine();
                continue;
            }

            int points = Integer.parseInt(tokens[2]);

            userPoints.putIfAbsent(user, 0);
            int max = Math.max(userPoints.get(user), points);
            userPoints.put(user, max);

            submissions.putIfAbsent(tech, 0);
            int count = submissions.get(tech);
            submissions.put(tech, count + 1);

            input = sc.nextLine();
        }

        System.out.println("Results:");
        userPoints.entrySet().stream()
                .sorted((e1,e2) -> e2.getValue().compareTo(e1.getValue()))
                .forEach(e -> System.out.println(String.format("%s | %d", e.getKey(), e.getValue())));

        System.out.println("Submissions:");
        submissions.entrySet().stream()
                .sorted((e1,e2) -> Integer.compare(e2.getValue(),e1.getValue()))
                .forEach(e -> System.out.println(String.format("%s - %d", e.getKey(),e.getValue())));
    }
}
