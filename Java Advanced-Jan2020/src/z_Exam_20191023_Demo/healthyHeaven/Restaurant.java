package z_Exam_20191023_Demo.healthyHeaven;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Restaurant {
    private String name;
    private List<Salad> data;

    public Restaurant(String name) {
        this.name = name;
        this.data = new ArrayList<>();
    }
    
    // adds an entity to the data
    public void add(Salad salad) {
        this.data.add(salad);
    }
        
    // removes a salad by given name, if such exists, and returns boolean
    public boolean buy(String name) {
        for (Salad salad : data) {
            if (salad.getName().equals(name)) {
                data.remove(salad);
                return true;
            }
        }
        return false;
    }
    
    // returns the healthiest salad
    public Salad getHealthiestSalad() {
        List<Salad> sortedSalads = data.stream()
                .sorted((f,s) -> f.getTotalCalories() - s.getTotalCalories())
                .collect(Collectors.toList());
        return sortedSalads.get(0);
    }

    public String generateMenu() {
        return String.format("%s have %d salads:%n",
                this.name, data.size()) +
                this.data.stream()
                        .map(e -> e.toString())
                        .collect(Collectors.joining(System.lineSeparator()));
    }
}
