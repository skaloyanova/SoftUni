package l_ObjectsAndClasses_Exercise.VehicleCatalogue;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String line = sc.nextLine();
        List<VehicleCatalogue> vehicles = new ArrayList<>();

        while (!"End".equals(line)) {

            String[] input = line.split("\\s+");
            String typeOfVehicle = input[0];
            String model = input[1];
            String color = input[2];
            int horsepower = Integer.parseInt(input[3]);

            if ("car".equals(typeOfVehicle)) {
                VehicleCatalogue vehicle = new VehicleCatalogue("Car", model, color, horsepower);
                vehicles.add(vehicle);
            } else if ("truck".equals(typeOfVehicle)) {
                VehicleCatalogue vehicle = new VehicleCatalogue("Truck", model, color, horsepower);
                vehicles.add(vehicle);
            }

            line = sc.nextLine();
        }

        String modelRequest = sc.nextLine();

        while (!"Close the Catalogue".equals(modelRequest)) {
            for (VehicleCatalogue vehicle : vehicles) {
                if (vehicle.getModel().equals(modelRequest)) {
                    System.out.println(vehicle);
                }
            }

            modelRequest = sc.nextLine();
        }

        averageHorsepowerPrint(vehicles, "Car");
        averageHorsepowerPrint(vehicles, "Truck");
    }

    private static void averageHorsepowerPrint(List<VehicleCatalogue> vehicles, String typeOfVehicle) {
        int sumHorsepower = 0;
        int count = 0;

        for (VehicleCatalogue vehicle : vehicles) {
            if (vehicle.getTypeOfVehicle().equals(typeOfVehicle)) {
                sumHorsepower += vehicle.getHorsepower();
                count++;
            }
        }

        double avgHorsepower;
        if (count == 0) {
            avgHorsepower = 0;
        } else {
            avgHorsepower = sumHorsepower * 1.0 / count;
        }
        System.out.println(String.format("%ss have average horsepower of: %.2f.", typeOfVehicle, avgHorsepower));

    }
}
