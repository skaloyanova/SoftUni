package n_AssociativeArrays_Exercise;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class SoftUniParking {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = Integer.parseInt(sc.nextLine());

        Map<String, String> cars = new LinkedHashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = sc.nextLine().split("\\s+");

            String action = tokens[0];
            String name = tokens[1];

            switch (action) {
                case "register":
                    String plate = tokens[2];
                    if (cars.containsKey(name)) {
                        System.out.printf("ERROR: already registered with plate number %s%n", cars.get(name));
                    } else {
                        cars.put(name, plate);
                        System.out.printf("%s registered %s successfully%n", name, plate);
                    }
                    break;
                case "unregister":
                    if (!cars.containsKey(name)) {
                        System.out.printf("ERROR: user %s not found%n", name);
                    } else {
                        cars.remove(name);
                        System.out.printf("%s unregistered successfully%n", name);
                    }
                    break;
            }
        }
        //output
        cars.forEach((k, v) -> System.out.println(String.format("%s => %s",k, v)));
    }
}
