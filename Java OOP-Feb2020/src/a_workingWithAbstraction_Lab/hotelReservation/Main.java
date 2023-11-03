package a_workingWithAbstraction_Lab.hotelReservation;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] input = readInputFrom(sc);

        PriceCalculator priceCalculator = createPriceCalculator(input);

        double price = priceCalculator.calculatePrice();

        System.out.printf("%.2f%n", price);
    }

    private static PriceCalculator createPriceCalculator(String[] input) {
        // <pricePerDay> <numberOfDays> <season> <discountType>
        double pricePerDay = Double.parseDouble(input[0]);
        int numberOfDays = Integer.parseInt(input[1]);

        Season season = Season.valueOf(input[2].toUpperCase());
        DiscountType discountType = DiscountType.valueOf(input[3].toUpperCase());

        return new PriceCalculator(pricePerDay, numberOfDays, season, discountType);
    }

    private static String[] readInputFrom(Scanner sc) {
        return sc.nextLine().trim().split("\\s+");
    }
}
