package l_ObjectsAndClasses_Exercise.OpinionPoll;

public class Person {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return this.name;
    }

    public int getAge() {
        return this.age;
    }

    public boolean isOver30() {
        return this.age > 30;
    }

    @Override
    public String toString(){
        return String.format("%s - %d", name, age);
    }
}
