package n_IteratorsAndComparators_Exercises.comparingObjects;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Person> people = new ArrayList<>();

        String input = sc.nextLine();
        while (!"END".equals(input)) {
            String[] tokens = input.split("\\s+");
            Person person = new Person(tokens[0], Integer.parseInt(tokens[1]), tokens[2]);
            people.add(person);

            input = sc.nextLine();
        }

        int n = Integer.parseInt(sc.nextLine());
        Person personToCompare = people.get(n - 1);

        int cntEqual = 0;
        int cntNotEqual = 0;
        for (Person person : people) {
            if (personToCompare.compareTo(person) == 0) {
                cntEqual++;
            } else {
                cntNotEqual++;
            }
        }

        if (cntEqual == 1) {
            System.out.println("No matches");
        } else {
            System.out.println(String.format("%d %d %d", cntEqual, cntNotEqual, people.size()));
        }
    }
}
