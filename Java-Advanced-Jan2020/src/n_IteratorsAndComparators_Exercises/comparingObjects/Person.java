package n_IteratorsAndComparators_Exercises.comparingObjects;

public class Person implements Comparable<Person> {
    private String name;
    private int age;
    private String town;

    public Person(String name, int age, String town) {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    @Override
    public String toString() {
        return this.name + " " + this.age + " " + this.town;
    }

    @Override
    public int compareTo(Person other) {
        int result = this.name.compareTo(other.name);
        if (result == 0) {
            result = this.age - other.age;
        }
        if (result == 0) {
            result = this.town.compareTo(other.town);
        }
        return result;
    }
}
