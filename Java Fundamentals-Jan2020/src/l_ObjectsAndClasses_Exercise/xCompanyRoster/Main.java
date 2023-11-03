package l_ObjectsAndClasses_Exercise.xCompanyRoster;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Employee> employees = new ArrayList<>();
        int n = Integer.parseInt(sc.nextLine());

        List<String> departments = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split("\\s+");

            String name = input[0];
            double salary = Double.parseDouble(input[1]);
            String position = input[2];
            String department = input[3];
            String email = "n/a";
            int age = -1;

            for (int j = 4; j < input.length; j++) {
                if (input[j].contains("@")) {
                    email = input[j];
                } else if (isInteger(input[j])) {
                    age = Integer.parseInt(input[j]);
                }
            }

            Employee worker = new Employee(name, salary, position, department, email, age);
            employees.add(worker);

            if (!departments.contains(department)) {
                departments.add(department);
            }
        }

        double highestAvgSalary = 0;
        String highestDep = "";
        for (String dep : departments) {
            if (avgDepSalary(employees, dep) >= highestAvgSalary) {
                highestAvgSalary = avgDepSalary(employees, dep);
                highestDep = dep;
            }
        }

        System.out.println("Highest Average Salary: " + highestDep);

        String finalHighestDep = highestDep;
        employees.stream()
                .filter(e -> e.getDepartment().equals(finalHighestDep))
                .sorted((e1, e2) -> Double.compare(e2.getSalary(), e1.getSalary()))
                .forEach(e -> System.out.println(e.toString()));

    }

    private static double avgDepSalary(List<Employee> employees, String dep) {
        double sum = 0.0;
        int count = 0;

        for (Employee empl : employees) {
            if (empl.getDepartment().equals(dep)) {
                sum += empl.getSalary();
                count++;
            }
        }
        return sum / count;
    }

    public static boolean isInteger(String s) {
        try {
            Integer.parseInt(s);
        } catch(NumberFormatException e) {
            return false;
        } catch(NullPointerException e) {
            return false;
        }
        // only got here if we didn't return false
        return true;
    }
}
