package j_polymorphism_Exercises.wildFarm;

public class Zebra extends Mammal {

    public Zebra(String animalType, String animalName, Double animalWeight, String livingRegion) {
        super(animalType, animalName, animalWeight, livingRegion);
    }

    @Override
    public void makeSound() {
        System.out.println("Zs");
    }

    @Override
    public void eat(Food food) {
        if (!"Vegetable".equals(food.getClass().getSimpleName())) {
            throw new IllegalStateException("Zebras are not eating that type of food!");
        }
        super.eat(food);
    }
}
