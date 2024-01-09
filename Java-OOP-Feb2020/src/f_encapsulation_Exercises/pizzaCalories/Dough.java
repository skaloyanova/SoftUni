package f_encapsulation_Exercises.pizzaCalories;

public class Dough {
    private String flourType;       //white, wholegrain
    private String bakingTechnique; //crispy, chewy, homemade
    private double weight;

    public Dough(String flourType, String bakingTechnique, double weight) {
        this.setFlourType(flourType);
        this.setBakingTechnique(bakingTechnique);
        this.setWeight(weight);
    }

    public double calculateCalories() {
        return 2 * weight
                * DoughType.valueOf(flourType.toUpperCase()).getModifier()
                * DoughType.valueOf(bakingTechnique.toUpperCase()).getModifier();
    }

    private void setFlourType(String flourType) {
        try {
            DoughType e = DoughType.valueOf(flourType.toUpperCase());
        } catch (Exception e) {
            throw new IllegalArgumentException("Invalid type of dough.");
        }
        this.flourType = flourType;
    }

    private void setBakingTechnique(String bakingTechnique) {
        try {
            DoughType e = DoughType.valueOf(bakingTechnique.toUpperCase());
        } catch (Exception e) {
            throw new IllegalArgumentException("Invalid type of dough.");
        }
        this.bakingTechnique = bakingTechnique;
    }

    private void setWeight(double weight) {
        if (weight < 1 || weight > 200) {
            throw new IllegalArgumentException("f_encapsulation_Exercises.pizzaCalories.Dough weight should be in the range [1..200].");
        }
        this.weight = weight;
    }
}
