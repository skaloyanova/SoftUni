package j_polymorphism_Exercises.wildFarm;

import java.text.DecimalFormat;

public abstract class Mammal extends Animal {
    private String livingRegion;

    public Mammal(String animalType, String animalName, Double animalWeight, String livingRegion) {
        super(animalType, animalName, animalWeight);
        this.livingRegion = livingRegion;
    }

    protected String getLivingRegion() {
        return livingRegion;
    }

    @Override
    public String toString() {
        return String.format("%s[%s, %s%s, %s, %d]",
                this.getAnimalType(),
                this.getAnimalName(),
                this.addSpecialText(),
                new DecimalFormat("#.##").format(this.getAnimalWeight()),
                this.getLivingRegion(),
                this.getFoodEaten());
    }

    protected String addSpecialText() {
        return "";
    }
}
