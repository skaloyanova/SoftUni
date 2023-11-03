package k_Generics_Lab.Animals;

public class Main {
    public static void main(String[] args) {

        Animal cat = new Cat();
        Animal dog = new Dog();

//        cat.makeNoise();
//        dog.makeNoise();

        AnimalList<Animal> list = new AnimalList<>();

        list.add(cat);
        list.add(dog);

        list.makeAllAnimalsNoise();

        System.out.println();
    }
}