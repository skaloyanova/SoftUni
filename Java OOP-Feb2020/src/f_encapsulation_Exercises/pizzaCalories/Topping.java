package f_encapsulation_Exercises.pizzaCalories;

public class Topping {
    private String toppingType;     //meat, veggies, cheese, sauce
    private double weight;

    public Topping(String toppingType, double weight) {
        this.setToppingType(toppingType);
        this.setWeight(weight);
    }

    public double calculateCalories() {
        return 2 * weight
                * ToppingType.valueOf(toppingType.toUpperCase()).getModifier();
    }

    private void setToppingType(String toppingType) {
        try {
            ToppingType tt = ToppingType.valueOf(toppingType.toUpperCase());
        } catch (Exception e) {
            throw new IllegalArgumentException("Cannot place " + toppingType + " on top of your pizza.");
        }
        this.toppingType = toppingType;
    }

    private void setWeight(double weight) {
        if (weight < 1 || weight > 50) {
            throw new IllegalArgumentException(this.toppingType + " weight should be in the range [1..50].");
        }
        this.weight = weight;
    }
}
