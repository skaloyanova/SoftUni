package n_AssociativeArrays_Exercise;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Scanner;

public class Orders {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();

        LinkedHashMap<String, List<Double>> products = new LinkedHashMap<>();

        while (!"buy".equals(input)) {
            String[] tokens = input.split(" ");

            String name = tokens[0];
            double price = Double.parseDouble(tokens[1]);
            double quantity = Double.parseDouble(tokens[2]);

            if (!products.containsKey(name)) {
                products.putIfAbsent(name, new ArrayList<>());
                products.get(name).add(0, price);
                products.get(name).add(1, quantity);
            } else {
                double oldQnty = products.get(name).get(1);
                products.get(name).set(0, price);
                products.get(name).set(1, oldQnty + quantity);
            }

            input = sc.nextLine();
        }

        products.forEach((key, value) -> {
            double totalPrice = value.get(0) * value.get(1);
            System.out.println(String.format("%s -> %.2f", key, totalPrice));
        });
    }
}
