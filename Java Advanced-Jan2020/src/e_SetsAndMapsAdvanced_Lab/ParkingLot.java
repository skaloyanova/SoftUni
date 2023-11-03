package e_SetsAndMapsAdvanced_Lab;

import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class ParkingLot {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Set<String> carsPlates = new LinkedHashSet<>();

        String input = sc.nextLine();
        while (!"END".equals(input)) {
            String[] tokens = input.split(", ");
            String direction = tokens[0];
            String plate = tokens[1];

            if ("IN".equals(direction)) {
                carsPlates.add(plate);
            } else if ("OUT".equals(direction)) {
                carsPlates.remove(plate);
            }

            input = sc.nextLine();
        }

        if (carsPlates.isEmpty()) {
            System.out.println("Parking Lot is Empty");
        } else {
            carsPlates.forEach(System.out::println);
        }
    }
}
