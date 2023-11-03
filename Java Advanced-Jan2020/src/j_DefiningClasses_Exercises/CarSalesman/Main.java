package j_DefiningClasses_Exercises.CarSalesman;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String,Engine> engines = new HashMap<>();
        Set<Car> cars = new LinkedHashSet<>();

        //read Engines
        int n = Integer.parseInt(sc.nextLine());
        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String model = tokens[0];
            int power = Integer.parseInt(tokens[1]);

            Engine engine;

            if (tokens.length == 2) {
                engine = new Engine(model, power);
            } else if (tokens.length == 4) {
                String displacement = tokens[2];
                String efficiency = tokens[3];
                engine = new Engine(model, power, displacement, efficiency);
            } else {
                try {
                    int num = Integer.parseInt(tokens[2]);
                    engine = new Engine(model, power);
                    engine.setDisplacement(tokens[2]);
                } catch (NumberFormatException ex) {
                    engine = new Engine(model, power);
                    engine.setEfficiency(tokens[2]);
                }
            }

            engines.put(model, engine);
        }

        //read Cars
        n = Integer.parseInt(sc.nextLine());
        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String model = tokens[0];
            String engineModel = tokens[1];  //this is the model of an existing Engine
            Engine engine = engines.get(engineModel);

            Car car;

            if (tokens.length == 2) {
                car = new Car(model, engine);
            } else if (tokens.length == 4) {
                String weight = tokens[2];
                String color = tokens[3];
                car = new Car(model, engine, weight, color);
            } else {
                try {
                    int num = Integer.parseInt(tokens[2]);
                    car = new Car(model, engine);
                    car.setWeight(tokens[2]);
                } catch (NumberFormatException ex) {
                    car = new Car(model, engine);
                    car.setColor(tokens[2]);
                }
            }

            cars.add(car);
        }

        // print
        for (Car car : cars) {
            System.out.println(car);
        }
    }
}
