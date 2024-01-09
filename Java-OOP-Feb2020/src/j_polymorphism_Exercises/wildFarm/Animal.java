package j_polymorphism_Exercises.wildFarm;

public abstract class Animal {
    private String animalType;
    private String animalName;
    private Double animalWeight;
    private Integer foodEaten;

    public Animal(String animalType, String animalName, Double animalWeight) {
        this.animalType = animalType;
        this.animalName = animalName;
        this.animalWeight = animalWeight;
        this.foodEaten = 0;
    }

    public abstract void makeSound();

    public void eat(Food food) {
        this.foodEaten += food.getQuantity();
    }

    protected String getAnimalType() {
        return animalType;
    }

    protected String getAnimalName() {
        return animalName;
    }

    protected Double getAnimalWeight() {
        return animalWeight;
    }

    protected Integer getFoodEaten() {
        return foodEaten;
    }
}
