package j_polymorphism_Exercises.vehicles;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Vehicle> vehicles = new ArrayList<>();

        for (int i = 0; i < 3; i++) {
            Vehicle vehicle = createNewVehicle(sc.nextLine());
            if (vehicle != null) {
                vehicles.add(vehicle);
            }
        }

        int n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String action = tokens[0];                          //Drive or Refuel or DriveEmpty
            String vehicleType = tokens[1];                     //j_polymorphism_Exercises.vehicles.Car or j_polymorphism_Exercises.vehicles.Truck or j_polymorphism_Exercises.vehicles.Bus
            double quantity = Double.parseDouble(tokens[2]);    //distance or liters

            for (Vehicle vehicle : vehicles) {
                try {
                    if (vehicleType.equals(vehicle.getClass().getSimpleName())) {
                        switch (action) {
                            case "Drive":
                                System.out.println(vehicle.drive(quantity));
                                break;
                            case "DriveEmpty":
                                System.out.println(vehicle.driveEmpty(quantity));
                                break;
                            case "Refuel":
                                vehicle.refuel(quantity);
                                break;
                        }
                    }
                } catch (IllegalArgumentException e) {
                    System.out.println(e.getMessage());
                }
            }

        }
        for (Vehicle vehicle : vehicles) {
            System.out.println(vehicle.showRemainingFuel());
        }
    }

    private static Vehicle createNewVehicle(String nextLine) {
        String[] tokens = nextLine.split("\\s+");
        switch (tokens[0]) {
            case "j_polymorphism_Exercises.vehicles.Car":
                return new Car(Double.parseDouble(tokens[1]),
                        Double.parseDouble(tokens[2]),
                        Integer.parseInt(tokens[3]));
            case "j_polymorphism_Exercises.vehicles.Truck":
                return new Truck(Double.parseDouble(tokens[1]),
                        Double.parseDouble(tokens[2]),
                        Integer.parseInt(tokens[3]));
            case "j_polymorphism_Exercises.vehicles.Bus":
                return new Bus(Double.parseDouble(tokens[1]),
                        Double.parseDouble(tokens[2]),
                        Integer.parseInt(tokens[3]));
            default:
                return null;
        }
    }
}
