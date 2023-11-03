package n_IteratorsAndComparators_Exercises.strategyPatternANDequalityLogic;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        /*------ Problem 6. Strategy Pattern ------*/
//        Set<Person> setByName = new TreeSet<>(new Person.CompareByName());
//        Set<Person> setByAge = new TreeSet<>(new Person.CompareByAge());
//
//        for (int i = 0; i < n; i++) {
//            String[] tokens = sc.nextLine().split("\\s+");
//            setByName.add(new Person(tokens[0], Integer.parseInt(tokens[1])));
//            setByAge.add(new Person(tokens[0], Integer.parseInt(tokens[1])));
//        }
//        //print
//        for (Person person : setByName) {
//            System.out.println(person);
//        }
//        for (Person person : setByAge) {
//            System.out.println(person);
//        }

        /*------ Problem 7. Equality Logic ------*/
        Set<Person> treeSet = new TreeSet<>();
        Set<Person> hashSet = new HashSet<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            Person person = new Person(tokens[0], Integer.parseInt(tokens[1]));
            System.out.println(person.hashCode());
            treeSet.add(person);
            hashSet.add(person);
        }

        System.out.println(treeSet.size());
        System.out.println(hashSet.size());

    }
}
