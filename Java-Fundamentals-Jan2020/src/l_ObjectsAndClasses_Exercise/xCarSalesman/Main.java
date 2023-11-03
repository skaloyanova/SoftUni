package l_ObjectsAndClasses_Exercise.xCarSalesman;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Engine> engines = new ArrayList<>();
        List<Car> cars = new ArrayList<>();

        //read Engines from console and add them to list

        int enginesCnt = Integer.parseInt(sc.nextLine());
        for (int i = 0; i < enginesCnt; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String model = tokens[0];
            String power = tokens[1];
            String displacement = "n/a";
            String efficiency = "n/a";

            for (int j = 2; j < tokens.length; j++) {
                if (isInteger(tokens[j])) {
                    displacement = tokens[j];
                } else {
                    efficiency = tokens[j];
                }
            }

            Engine engine = new Engine(model, power, displacement, efficiency);
            engines.add(engine);
        }

        //read Cars from console and add them to list

        int carsCnt = Integer.parseInt(sc.nextLine());
        for (int i = 0; i < carsCnt; i++) {
            String[] tokens = sc.nextLine().split("\\s+");
            String model = tokens[0];
            String engineModel = tokens[1];
            Engine engineCurrent = null;
            String weight = "n/a";
            String color = "n/a";

            for (Engine eng : engines) {
                if (eng.getModel().equals(engineModel)) {
                    engineCurrent = eng;
                    break;
                }
            }

            for (int j = 2; j < tokens.length; j++) {
                if (isInteger(tokens[j])) {
                    weight = tokens[j];
                } else {
                    color = tokens[j];
                }
            }

            Car car = new Car(model, engineCurrent, weight, color);
            cars.add(car);
        }

        //print
        for (Car car : cars) {
            System.out.println(car);
        }
    }

    public static boolean isInteger(String s) {
        try {
            Integer.parseInt(s);
        } catch(NumberFormatException e) {
            return false;
        } catch(NullPointerException e) {
            return false;
        }
        // only got here if we didn't return false
        return true;
    }
}
