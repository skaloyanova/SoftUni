package d_inheritance_Exercises.animals;

public class Animal {

    private String name;
    private int age;
    private String gender;

    public Animal(String name, int age, String gender) {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    public String produceSound() {
        return "";
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getGender() {
        return gender;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append(this.getClass().getSimpleName()).append(System.lineSeparator());
        sb.append(String.format("%s %d %s", name, age, gender)).append(System.lineSeparator());
        sb.append(this.produceSound());

        return sb.toString();
    }
}
