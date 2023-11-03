package o_FunctionalProgramming_Lab;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Consumer;
import java.util.function.Predicate;

public class FilterByAge {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        List<Person> people = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split(", ");
            people.add(new Person(tokens[0], Integer.parseInt(tokens[1])));
        }

        String condition = sc.nextLine();           // "younger" or "older"
        int age = Integer.parseInt(sc.nextLine());  // int number
        String format = sc.nextLine();              // "name", "age" or "name age"

        Predicate<Person> filterByAge = (x) -> {
            if ("younger".equals(condition)) {
                return x.getAge() <= age;
            }
            if ("older".equals(condition)) {
                return x.getAge() >= age;
            }
            return false;
        };

        Consumer<Person> print = (x) -> {
            switch (format) {
                case "name":
                    System.out.println(x.getName());
                    break;
                case "age":
                    System.out.println(x.getAge());
                    break;
                default:
                    System.out.println(String.format("%s - %d", x.getName(), x.getAge()));
            }
        };

        //var1 - stream
        people.stream()
                .filter(filterByAge)
                .forEach(print);

        //var2 - forEach
//        for (Person person : people) {
//            if (filterByAge.test(person)) {
//                print.accept(person);
//            }
//        }

    }

    public static class Person {
        private String name;
        private int age;

        public Person(String name, int age) {
            this.name = name;
            this.age = age;
        }

        public String getName() {
            return name;
        }

        public int getAge() {
            return age;
        }
    }
}
