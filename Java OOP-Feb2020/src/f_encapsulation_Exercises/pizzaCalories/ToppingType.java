package f_encapsulation_Exercises.pizzaCalories;

public enum ToppingType {
    MEAT(1.2),
    VEGGIES(0.8),
    CHEESE(1.1),
    SAUCE(0.9);

    private final double modifier;

    ToppingType(double modifier) {
        this.modifier = modifier;
    }

    public double getModifier() {
        return modifier;
    }
}
