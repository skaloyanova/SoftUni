package j_polymorphism_Exercises.wildFarm;

public class Tiger extends Feline {

    public Tiger(String animalType, String animalName, Double animalWeight, String livingRegion) {
        super(animalType, animalName, animalWeight, livingRegion);
    }

    @Override
    public void makeSound() {
        System.out.println("ROAAR!!!");
    }

    @Override
    public void eat(Food food) {
        if (!"Meat".equals(food.getClass().getSimpleName())) {
            throw new IllegalStateException ("Tigers are not eating that type of food!");
        }
        super.eat(food);
    }
}
