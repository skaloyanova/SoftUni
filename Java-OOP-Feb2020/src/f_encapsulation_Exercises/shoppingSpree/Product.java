package f_encapsulation_Exercises.shoppingSpree;

public class Product {
    private String name;
    private double cost;

    public Product(String name, double cost) {
        this.setName(name);
        this.setCost(cost);
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        Validator.validateName(name);
        this.name = name.trim();
    }

    public double getCost() {
        return cost;
    }

    private void setCost(double cost) {
        Validator.validateMoney(cost);
        this.cost = cost;
    }
}
