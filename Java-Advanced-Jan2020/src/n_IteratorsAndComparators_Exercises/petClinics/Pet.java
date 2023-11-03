package n_IteratorsAndComparators_Exercises.petClinics;

public class Pet {
    private String name;
    private int age;
    private String type;

    public Pet(String name, int age, String type) {
        this.name = name;
        this.age = age;
        this.type = type;
    }

    @Override
    public String toString() {
        return name + " " + age + " " + type;
    }
}
