package a_BasicSyntaxCondStatementsLoops_Lab;

import java.util.Scanner;

public class StudentInformation {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String name = sc.nextLine();
        int age = Integer.parseInt(sc.nextLine());
        double avgGrade = Double.parseDouble(sc.nextLine());

        System.out.printf("Name: %s, Age: %d, Grade: %.2f", name, age, avgGrade);
    }
}
