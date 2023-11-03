package k_ObjectsAndClasses.Students;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ArrayList<Students> students = new ArrayList<>();

        while (true) {
            String input = sc.nextLine();
            if ("end".equals(input)) {
                break;
            }

            String[] tokens = input.split("\\s+");

            String firstN = tokens[0];
            String lastN = tokens[1];
            int age = Integer.parseInt(tokens[2]);
            String home = tokens[3];

            Students pupil = new Students(firstN, lastN, age, home);

            // START of code for Students 2.0 task
            students.removeIf(st -> st.getFirstName().equals(firstN) && st.getLastName().equals(lastN));
            // END of code for Students 2.0

            students.add(pupil);
        }

        String city = sc.nextLine();

        for (Students st : students) {
            if (st.getHometown().equals(city)) {
                System.out.printf("%s %s is %d years old%n", st.getFirstName(), st.getLastName(), st.getAge());
            }
        }
    }
}
