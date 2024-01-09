package f_encapsulation_Exercises.animalFarm;

public class Chicken {
    private String name;
    private int age;

    public Chicken(String name, int age) {
        setName(name);
        setAge(age);
    }

    public double productPerDay() {
        return calculateProductPerDay();
    }

    private double calculateProductPerDay() {
        if (this.getAge() <= 5) {
            return 2;
        } else if (this.getAge() <= 11) {
            return 1;
        } else {
            return 0.75;
        }
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        if (name == null || name.length() < 1 || name.matches("\\s+")) {
            throw new IllegalArgumentException("Name cannot be empty.");
        }
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    private void setAge(int age) {
        if (age > 15 || age < 0) {
            throw new IllegalArgumentException("Age should be between 0 and 15.");
        }
        this.age = age;
    }

    //f_encapsulation_Exercises.AnimalFarm.Chicken Mara (age 10) can produce 1.00 eggs per day.
    @Override
    public String toString() {
        return String.format("f_encapsulation_Exercises.AnimalFarm.Chicken %s (age %d) can produce %.2f eggs per day.",
                this.getName(),
                this.getAge(),
                this.calculateProductPerDay());
    }
}
