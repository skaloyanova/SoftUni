package a_workingWithAbstraction_Lab.studentSystem;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        StudentSystem studentSystem = new StudentSystem(new InMemoryStudentRepository());

        while (true) {
            String[] input = scanner.nextLine().split(" ");
            String command = input[0];

            switch (command) {
                case "Exit":
                    return;
                case "Create":
                    Student student = createStudent(input);
                    studentSystem.saveUniqueStudentToRepo(student);
                    break;
                case "Show":
                    String studentInfo = studentSystem.returnStudentInformation(input[1]);
                    if (studentInfo != null) {
                        System.out.println(studentInfo);
                    }
                    break;
            }
        }
    }

    // Create <studentName> <studentAge> <studentGrade>
    private static Student createStudent(String[] args) {
        String name = args[1];
        var age = Integer.parseInt(args[2]);
        var grade = Double.parseDouble(args[3]);

        return new Student(name, age, grade);
    }
}
