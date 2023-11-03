package i_DefiningClasses_Lab.CarInfo;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        List<Car> cars = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = sc.nextLine().split("\\s+");

            Car currentCar = new Car(input[0]);
            if (input.length == 3) {
                currentCar = new Car(input[0], input[1], Integer.parseInt(input[2]));
            }

            cars.add(currentCar);
        }

        for (Car car : cars) {
            System.out.println(car.carInfo());
        }
    }
}
