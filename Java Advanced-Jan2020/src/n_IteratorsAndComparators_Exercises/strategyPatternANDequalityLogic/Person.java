package n_IteratorsAndComparators_Exercises.strategyPatternANDequalityLogic;

import java.util.Comparator;

public class Person implements Comparable<Person> {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public String toString() {
        return this.name + " " + this.age;
    }

    @Override
    public int compareTo(Person o) {
        int result = this.name.compareTo(o.name);
        if (result == 0) {
            result = this.age - o.age;
        }
        return result;
    }

    @Override
    public boolean equals(Object other) {
        if (this == other) {
            return true;
        }

        if (this.getClass() != other.getClass()) {
            return false;
        }

        Person person = (Person) other;
        return this.name.equals(person.name) && this.age == person.age;

    }

    @Override
    public int hashCode() {
        return this.name.hashCode() + Integer.hashCode(this.age) * 73;
    }

    public static class CompareByName implements Comparator<Person> {

        @Override
        public int compare(Person o1, Person o2) {
            int result = o1.name.length() - o2.name.length();
            if (result == 0) {
                result = Character.compare(o1.name.toLowerCase().charAt(0), o2.name.toLowerCase().charAt(0));
            }
            return result;
        }
    }

    public static class CompareByAge implements Comparator<Person> {

        @Override
        public int compare(Person o1, Person o2) {
            return o1.age - o2.age;
        }
    }
}
