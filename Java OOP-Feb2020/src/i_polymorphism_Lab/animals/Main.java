package i_polymorphism_Lab.animals;

public class Main {

    public static void main(String[] args) {
        Animal cat = new Cat("Oscar", "Whiskas");
        Animal dog = new Dog("Rocky", "j_polymorphism_Exercises.wildFarm.Meat");
        System.out.println(cat.explainSelf());
        System.out.println(dog.explainSelf());
    }

}
