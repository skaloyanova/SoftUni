package e_SetsAndMapsAdvanced_Lab;

import java.util.*;

public class AverageStudentsGrades {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, List<Double>> grades = new TreeMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String name = tokens[0];
            double grade = Double.parseDouble(tokens[1]);

            grades.putIfAbsent(name, new ArrayList<>());
            grades.get(name).add(grade);
        }
        grades.forEach((k,v) -> {
            StringBuilder listGrades = new StringBuilder();
            double sum = 0;
            for (Double aDouble : v) {
                listGrades.append(String.format("%.2f ",aDouble));
                sum += aDouble;
            }
            double avgGrade = sum / v.size();
            String output = String.format("%s -> %s(avg: %.2f)", k, listGrades, avgGrade);
            System.out.println(output);
        });
    }
}
