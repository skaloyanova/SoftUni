package l_ObjectsAndClasses_Exercise.xRawData;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        List<Car> cars = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[]tokens = sc.nextLine().split("\\s+");

            String model = tokens[0];
            int engineSpeed = Integer.parseInt(tokens[1]);
            int enginePower = Integer.parseInt(tokens[2]);
            int cargoWeight = Integer.parseInt(tokens[3]);
            String cargoType = tokens[4];
            double tire1Pressure = Double.parseDouble(tokens[5]);
            int tire1Age = Integer.parseInt(tokens[6]);
            double tire2Pressure = Double.parseDouble(tokens[7]);
            int tire2Age = Integer.parseInt(tokens[8]);
            double tire3Pressure = Double.parseDouble(tokens[9]);
            int tire3Age = Integer.parseInt(tokens[10]);
            double tire4Pressure = Double.parseDouble(tokens[11]);
            int tire4Age = Integer.parseInt(tokens[12]);

            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                    tire1Pressure, tire1Age, tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age, tire4Pressure, tire4Age);

            cars.add(car);
        }

        String filterCargoType = sc.nextLine();

        if ("fragile".equals(filterCargoType)) {
            cars.stream()
                    .filter(c -> c.getCargoType().equals("fragile"))
                    .filter(c -> (c.getTire1Pressure() < 1 || c.getTire2Pressure() < 1 ||
                            c.getTire3Pressure() < 1 || c.getTire4Pressure() < 1))
                    .forEach(c -> System.out.println(c.toString()));

        } else if ("flamable".equals(filterCargoType)) {
            cars.stream()
                    .filter(c -> c.getCargoType().equals("flamable"))
                    .filter(c -> c.getEnginePower() > 250)
                    .forEach(c -> System.out.println(c.toString()));
        }
    }
}
