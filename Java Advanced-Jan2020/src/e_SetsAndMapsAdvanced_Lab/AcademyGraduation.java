package e_SetsAndMapsAdvanced_Lab;

import java.util.*;
import java.util.stream.Collectors;

public class AcademyGraduation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, List<Double>> students = new TreeMap<>();

        for (int i = 0; i < n; i++) {
            String name = sc.nextLine();
            List<Double> grades = Arrays.stream(sc.nextLine().split("\\s+"))
                    .map(Double::parseDouble).collect(Collectors.toList());
            students.putIfAbsent(name, new ArrayList<>());
            students.put(name, grades);
        }
        students.forEach((k, v) -> {
            double sum = 0;
            for (Double grade : v) {
                sum += grade;
            }
            double avgGrade = sum / v.size();
            System.out.println(String.format("%s is graduated with %s", k, avgGrade));
        });
    }
}
