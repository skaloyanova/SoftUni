package n_AssociativeArrays_Exercise;

import java.util.*;

public class Courses {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, List<String>> courses = new LinkedHashMap<>();

        String input = sc.nextLine();

        while (!"end".equals(input)) {
            String[] tokens = input.split(" : ");

            String courseName = tokens[0];
            String studentName = tokens[1];

            courses.putIfAbsent(courseName, new ArrayList<>());
            courses.get(courseName).add(studentName);

            input = sc.nextLine();
        }

        courses.entrySet().stream()
                .sorted((c1,c2) -> Integer.compare(c2.getValue().size(), c1.getValue().size()))
                .forEach((c -> {
                    System.out.println(String.format("%s: %d", c.getKey(), c.getValue().size()));
                    c.getValue().stream()
                            .sorted(String::compareTo)
                            .forEach(st -> System.out.println("-- " + st));
                }));
    }
}
