package k_Generics_Lab.Animals;

import java.util.ArrayList;

public class AnimalList<T extends Animal> {
    private ArrayList<T> animals;

    public AnimalList() {
        this.animals = new ArrayList<>();
    }

    public void add(T animal) {
        this.animals.add(animal);
    }

    public void makeAllAnimalsNoise() {
        for (T animal : animals) {
            animal.makeNoise();
        }
    }
}
