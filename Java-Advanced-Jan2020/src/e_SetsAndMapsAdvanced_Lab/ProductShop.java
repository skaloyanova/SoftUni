package e_SetsAndMapsAdvanced_Lab;

import java.util.*;

public class ProductShop {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Map<String, List<String>> stores = new TreeMap<>();

        String input = sc.nextLine();
        while (!"Revision".equals(input)) {
            String[] tokens = input.split(", ");
            String shop = tokens[0];
            String product = tokens[1];
            double price = Double.parseDouble(tokens[2]);

            String productList = String.format("%s, Price: %.1f", product, price);

            stores.putIfAbsent(shop, new ArrayList<>());
            stores.get(shop).add(productList);

            input = sc.nextLine();
        }
        stores.forEach((k,v) -> {
            System.out.println(k + "->");
            v.forEach(e -> System.out.println(String.format("Product: %s", e)));
        });
    }
}
