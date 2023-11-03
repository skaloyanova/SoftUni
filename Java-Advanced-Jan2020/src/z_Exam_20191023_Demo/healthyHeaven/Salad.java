package z_Exam_20191023_Demo.healthyHeaven;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Salad {
    private String name;
    private List<Vegetable> products;

    public Salad(String name) {
        this.name = name;
        this.products = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    //returns the sum of all vegetable calories in the salad
    public int getTotalCalories() {
        return products.stream().map(e -> e.getCalories()).mapToInt(Integer::intValue).sum();
    }

    // returns the number of products
    public int getProductCount() {
        return this.products.size();
    }

    // adds an entity to the products
    public void add(Vegetable product) {
        this.products.add(product);
    }

    @Override
    public String toString() {
        return String.format("* Salad %s is %d calories and have %d products:%n",
                this.name, getTotalCalories(), getProductCount()) +
                this.products.stream()
                        .map(e -> e.toString())
                        .collect(Collectors.joining(System.lineSeparator()));
    }
}
