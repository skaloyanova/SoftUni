package l_ObjectsAndClasses_Exercise.Students;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());
        List<Students> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split("\\s+");

            Students student = new Students(input[0], input[1], Double.parseDouble(input[2]));

            students.add(student);
        }

        students.stream()
                .sorted((s1, s2) -> Double.compare(s2.getGrade(), s1.getGrade()))
                .forEach(s -> System.out.println(s.toString()));
    }
}
