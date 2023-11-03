package z_Exam_20180610_archived;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Ranking {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, String> contests = new HashMap<>();
        Map<String, Student> students = new TreeMap<>();

        String input = sc.nextLine();
        while (!"end of contests".equals(input)) {
            String[] tokens = input.split(":");
            contests.put(tokens[0], tokens[1]);
            input = sc.nextLine();
        }

        input = sc.nextLine();
        while (!"end of submissions".equals(input)) {
            String[] tokens = input.split("=>");

            String contest = tokens[0];
            String password = tokens[1];
            String username = tokens[2];
            int points = Integer.parseInt(tokens[3]);

            if (contests.containsKey(contest) && contests.get(contest).equals(password)) {
                students.putIfAbsent(username, new Student(username));

               students.get(username).addContest(contest, points);
            }

            input = sc.nextLine();
        }

        // print
        students.values().stream()
                .sorted((f,s) -> Integer.compare(s.getTotalPoints(), f.getTotalPoints()))
                .limit(1)
                .forEach(e -> System.out.println(String.format("Best candidate is %s with total %d points.",
                        e.getUsername(), e.getTotalPoints())));

        System.out.println("Ranking:");
        students.values().forEach(System.out::println);

    }

    private static class Student {
        private String username;
        private Map<String, Integer> contests;

        public Student(String username) {
            this.username = username;
            this.contests = new HashMap<>();
        }

        public void addContest(String contest, int points) {
            contests.putIfAbsent(contest, points);

            if (this.contests.get(contest) < points) {
                contests.put(contest, points);
            }
        }

        public int getTotalPoints() {
            int sum = 0;
            for (Integer value : contests.values()) {
                sum += value;
            }
            return sum;
        }

        public String getUsername() {
            return username;
        }

        @Override
        public String toString() {
            StringBuilder sb = new StringBuilder();
            sb.append(this.username).append(System.lineSeparator());
            contests.entrySet().stream()
                    .sorted((f,s) -> Integer.compare(s.getValue(), f.getValue()))
                    .forEach(e -> sb.append(String.format("#  %s -> %d%n", e.getKey(), e.getValue())));

            return sb.toString().trim();
        }
    }
}
