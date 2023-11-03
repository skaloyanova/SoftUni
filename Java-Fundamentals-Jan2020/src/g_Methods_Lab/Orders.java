package g_Methods_Lab;

import java.util.Scanner;

public class Orders {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String product = sc.nextLine();
        int quantity = Integer.parseInt(sc.nextLine());

        calculateCost(product, quantity);

    }

    private static void calculateCost(String product, int quantity) {
        double price = 0.0;
        switch (product) {
            case "coffee": price = 1.50 * quantity; break;
            case "water": price = 1.00 * quantity; break;
            case "coke": price = 1.40 * quantity; break;
            case "snacks": price = 2.00 * quantity; break;
        }
        System.out.println(String.format("%.2f", price));
    }
}
