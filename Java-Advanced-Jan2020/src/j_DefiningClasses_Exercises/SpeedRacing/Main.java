package j_DefiningClasses_Exercises.SpeedRacing;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, Car> cars = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String model = tokens[0];
            double fuelAmount = Double.parseDouble(tokens[1]);
            double fuelCostPerKm = Double.parseDouble(tokens[2]);
            cars.put(model, new Car(model, fuelAmount, fuelCostPerKm));
        }

        String input = sc.nextLine();
        while (!"End".equals(input)) {
            String[] tokens = input.split("\\s+");
            String carModel = tokens[1];
            int distanceKm = Integer.parseInt(tokens[2]);

            cars.get(carModel).driveCar(distanceKm);

            input = sc.nextLine();
        }

        //print
        for (Car car : cars.values()) {
            System.out.println(car);
        }
    }
}
