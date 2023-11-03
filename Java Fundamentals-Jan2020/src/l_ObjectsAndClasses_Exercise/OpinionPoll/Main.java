package l_ObjectsAndClasses_Exercise.OpinionPoll;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        ArrayList<Person> people = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split(" ");

            String name = input[0];
            int age = Integer.parseInt(input[1]);

            Person person = new Person(name, age);

            people.add(person);
        }

        people.stream()
                .filter(p -> p.getAge() > 30)
                .sorted((p1, p2) -> p1.getName().compareTo(p2.getName()))
                .forEach(p -> System.out.println(p));

        // VARIANT 1 without using stream
//        ArrayList<String> result = new ArrayList<>();
//
//        for (Person person : people) {
//            if (person.isOver30()) {
//                result.add(person.toString());
//            }
//        }
//
//        Collections.sort(result);
//
//        for (String p : result) {
//            System.out.println(p);
//        }
    }
}
