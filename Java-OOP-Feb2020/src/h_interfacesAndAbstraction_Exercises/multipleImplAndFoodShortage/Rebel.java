package h_interfacesAndAbstraction_Exercises.multipleImplAndFoodShortage;

public class Rebel implements Person, Buyer {
    private String name;
    private int age;
    private String group;
    private int food = 0;

    public Rebel(String name, int age, String group) {
        this.name = name;
        this.age = age;
        this.group = group;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public int getAge() {
        return age;
    }

    public String getGroup() {
        return group;
    }

    @Override
    public int getFood() {
        return food;
    }

    @Override
    public void buyFood() {
        this.food += 5;
    }
}
