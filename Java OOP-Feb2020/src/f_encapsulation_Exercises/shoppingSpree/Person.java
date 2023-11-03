package f_encapsulation_Exercises.shoppingSpree;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Person {
    private String name;
    private double money;
    private List<Product> products;

    public Person(String name, double money) {
        this.setName(name);
        this.setMoney(money);
        this.products = new ArrayList<>();
    }

    public void buyProduct(Product product) {
        if (this.getMoney() < product.getCost()) {
            throw new IllegalStateException(String.format("%s can't afford %s", this.getName(), product.getName()));
        }
        products.add(product);
        money -= product.getCost();
    }

    @Override
    public String toString() {
        if (products.isEmpty()) {
            return this.name + " – Nothing bought";
        } else {
            return this.name + " - " +
                    products.stream()
                    .map(e -> e.getName())
                    .collect(Collectors.joining(", "));
        }
    }

    private void setName(String name) {
        Validator.validateName(name);
        this.name = name.trim();
    }

    private void setMoney(double money) {
        Validator.validateMoney(money);
        this.money = money;
    }

    public String getName() {
        return name;
    }

    public double getMoney() {
        return money;
    }
}
