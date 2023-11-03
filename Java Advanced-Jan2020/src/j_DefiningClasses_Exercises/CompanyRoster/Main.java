package j_DefiningClasses_Exercises.CompanyRoster;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        List<Employee> employees =new ArrayList<>();
        Map<String,List<Double>> departmentSalary = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String name = tokens[0];
            double salary = Double.parseDouble(tokens[1]);
            String position = tokens[2];
            String department = tokens[3];

            if (tokens.length == 4) {
                employees.add(new Employee(name, salary, position, department));
            } else if (tokens.length == 6) {
                employees.add(new Employee(name, salary, position, department, tokens[4], Integer.parseInt(tokens[5])));
            } else {
                try {
                    int age = Integer.parseInt(tokens[4]);
                    employees.add(new Employee(name, salary, position, department, age));
                } catch (NumberFormatException nfe) {
                    employees.add(new Employee(name, salary, position, department, tokens[4]));
                }
            }

            departmentSalary.putIfAbsent(department, new ArrayList<>());
            departmentSalary.get(department).add(salary);
        }

        double maxAvgSalary = -Double.MAX_VALUE;
        String depWithMaxAvgSal = "";
        for (Map.Entry<String, List<Double>> entry : departmentSalary.entrySet()) {
            double average = entry.getValue()
                    .stream()
                    .mapToDouble(d -> d)
                    .average().getAsDouble();
            if (average > maxAvgSalary) {
                maxAvgSalary = average;
                depWithMaxAvgSal = entry.getKey();
            }
        }

        String finalDepWithMaxAvgSal = depWithMaxAvgSal;
        System.out.println("Highest Average Salary: " + finalDepWithMaxAvgSal);
        employees.stream()
                .filter(e -> e.getDepartment().equals(finalDepWithMaxAvgSal))
                .sorted((s1,s2) -> Double.compare(s2.getSalary(), s1.getSalary()))
                .forEach(e -> System.out.println(e));
    }
}
