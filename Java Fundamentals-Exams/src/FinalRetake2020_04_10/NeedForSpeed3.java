package FinalRetake2020_04_10;

import java.util.*;

public class NeedForSpeed3 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, List<Integer>> cars = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\|");
            String car = tokens[0];
            int mileage = Integer.parseInt(tokens[1]);
            int fuel = Integer.parseInt(tokens[2]);
            cars.put(car, new ArrayList<>());
            cars.get(car).add(mileage);
            cars.get(car).add(fuel);
        }

        String command = sc.nextLine();
        while (!"Stop".equals(command)) {
            String[] tokens = command.split(" : ");
            String action = tokens[0];
            String car = tokens[1];

            // index 0 -> mileage; index 1 -> fuel
            switch (action) {
                case "Drive":
                    int distance = Integer.parseInt(tokens[2]);
                    int fuel = Integer.parseInt(tokens[3]);

                    List<Integer> currentCar = cars.get(car);
                    if (currentCar.get(1) < fuel) {
                        System.out.println("Not enough fuel to make that ride");
                        break;
                    }
                    currentCar.set(0, currentCar.get(0) + distance);
                    currentCar.set(1, currentCar.get(1) - fuel);
                    System.out.printf("%s driven for %d kilometers. %d liters of fuel consumed.%n", car, distance, fuel);

                    if (currentCar.get(0) >= 100_000) {
                        cars.remove(car);
                        System.out.printf("Time to sell the %s!%n", car);
                    }
                    break;
                case "Refuel":
                    int fuelR = Integer.parseInt(tokens[2]);
                    int curFuel = cars.get(car).get(1);
                    if (fuelR + curFuel > 75) {
                        fuelR = 75 - curFuel;
                    }
                    cars.get(car).set(1, curFuel + fuelR);
                    System.out.printf("%s refueled with %d liters%n", car, fuelR);
                    break;
                case "Revert":
                    int km = Integer.parseInt(tokens[2]);
                    int newMileage = cars.get(car).get(0) - km;
                    if (newMileage < 10000) {
                        cars.get(car).set(0, 10000);
                        km = cars.get(car).get(0) - 10000;
                        break;
                    }
                    cars.get(car).set(0, newMileage);
                    System.out.printf("%s mileage decreased by %d kilometers%n", car, km);

                    break;
            }
            command = sc.nextLine();
        }
        cars.entrySet()
                .stream()
                .sorted((c1,c2) -> {
                    int res = c2.getValue().get(0).compareTo(c1.getValue().get(0));
                    if (res == 0) {
                        res = c1.getKey().compareTo(c2.getKey());
                    }
                    return res;
                })
                .forEach(e -> System.out.println(String.format("%s -> Mileage: %d kms, Fuel in the tank: %d lt.",
                        e.getKey(), e.getValue().get(0), e.getValue().get(1))));
    }
}
