package f_encapsulation_Exercises.pizzaCalories;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] pizzaParams = sc.nextLine().split("\\s+");     //ex. f_encapsulation_Exercises.pizzaCalories.Pizza Meatless 2
        Pizza pizza = new Pizza(pizzaParams[1], Integer.parseInt(pizzaParams[2]));

        String[] doughParams = sc.nextLine().split("\\s+");     //ex. f_encapsulation_Exercises.pizzaCalories.Dough Wholegrain Crispy 100
        Dough dough = new Dough(doughParams[1], doughParams[2], Double.parseDouble(doughParams[3]));

        pizza.setDough(dough);

        String toppingInput = sc.nextLine();
        while (!"END".equals(toppingInput)) {
            String[] toppingParams = toppingInput.split("\\s+");    //ex. f_encapsulation_Exercises.pizzaCalories.Topping Veggies 50
            Topping topping = new Topping(toppingParams[1], Double.parseDouble(toppingParams[2]));

            pizza.addTopping(topping);

            toppingInput = sc.nextLine();
        }

        System.out.printf("%s - %.2f%n", pizza.getName(), pizza.getOverallCalories());
    }
}
