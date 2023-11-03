package j_DefiningClasses_Exercises.RawData;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Set<Car> cars = new LinkedHashSet<>();

        int n = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < n; i++) {
            String[] token = sc.nextLine().split("\\s+");
            String model = token[0];
            String engineSpeed = token[1];
            int enginePower = Integer.parseInt(token[2]);
            String cargoWeight = token[3];
            String cargoType = token[4];
            double tire1Pressure = Double.parseDouble(token[5]);
            String tire1Age = token[6];
            double tire2Pressure = Double.parseDouble(token[7]);
            String tire2Age = token[8];
            double tire3Pressure = Double.parseDouble(token[9]);
            String tire3Age = token[10];
            double tire4Pressure = Double.parseDouble(token[11]);
            String tire4Age = token[12];

            Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                    tire1Pressure, tire1Age, tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age, tire4Pressure, tire4Age);
            cars.add(newCar);
        }

        //output
        String fragileOrFlamable = sc.nextLine();
        if ("fragile".equals(fragileOrFlamable)) {
            cars.stream()
                    .filter(c -> "fragile".equals(c.getCarCargoType()))
                    .filter(t -> t.isCarTyrePressureBelow1())
                    .forEach(e -> System.out.println(e.getModel()));
        } else if ("flamable".equals(fragileOrFlamable)) {
            cars.stream()
                    .filter(c -> "flamable".equals(c.getCarCargoType()))
                    .filter(Car::isCarPowerAbove250)
                    .forEach(e -> System.out.println(e.getModel()));
        }
    }
}
