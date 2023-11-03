package j_DefiningClasses_Exercises.OpinionPoll;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        List<Person> people = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split("\\s+");
            Person currentPerson = new Person(input[0], Integer.parseInt(input[1]));
            people.add(currentPerson);
        }

        people.stream()
                .filter(e -> e.getAge() > 30)
                .sorted((p1,p2) -> p1.getName().compareTo(p2.getName()))
                .forEach(e -> System.out.println(e.getName() + " - " + e.getAge()));
    }
}
