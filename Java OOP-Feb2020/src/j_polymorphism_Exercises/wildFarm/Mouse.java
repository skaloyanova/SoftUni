package j_polymorphism_Exercises.wildFarm;

public class Mouse extends Mammal {

    public Mouse(String animalType, String animalName, Double animalWeight, String livingRegion) {
        super(animalType, animalName, animalWeight, livingRegion);
    }

    @Override
    public void makeSound() {
        System.out.println("SQUEEEAAAK!");
    }

    @Override
    public void eat(Food food) {
        if (!"Vegetable".equals(food.getClass().getSimpleName())) {
            throw new IllegalStateException("Mice are not eating that type of food!");
        }
        super.eat(food);
    }
}
