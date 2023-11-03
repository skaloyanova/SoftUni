package n_AssociativeArrays_Exercise;

import java.util.*;

public class StudentAcademy {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, List<Double>> students = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String name = sc.nextLine();
            double grade = Double.parseDouble(sc.nextLine());

            students.putIfAbsent(name, new ArrayList<>());
            students.get(name).add(grade);

        }

        students.entrySet().stream()
                .filter(s -> s.getValue().stream().mapToDouble(Double::doubleValue).average().getAsDouble() >= 4.5)
                .sorted((s1,s2) -> {
                    double second = s2.getValue().stream().mapToDouble(Double::doubleValue).average().getAsDouble();
                    double first = s1.getValue().stream().mapToDouble(Double::doubleValue).average().getAsDouble();
                    return Double.compare(second, first);
                })
                .forEach(s -> System.out.println(String.format("%s -> %.2f", s.getKey()
                        , s.getValue().stream().mapToDouble(Double::doubleValue).average().getAsDouble())));
    }
}
