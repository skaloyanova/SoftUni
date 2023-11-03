package h_interfacesAndAbstraction_Exercises.multipleImplAndFoodShortage;

import java.util.*;

public class Main {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        Map<String, Buyer> buyers = new HashMap<>();

        int numberOfPeople = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < numberOfPeople; i++) {
            String[] split = sc.nextLine().split("\\s+");

            //"<name> <age> <id> <birthdate>" for Citizen
            //"<name> <age> <group>" for Rebel

            if (split.length == 4) {
                buyers.putIfAbsent(split[0], new Citizen(split[0], Integer.parseInt(split[1]), split[2], split[3]));
            } else if (split.length == 3) {
                buyers.putIfAbsent(split[0], new Rebel(split[0], Integer.parseInt(split[1]), split[2]));
            }
        }

        String name = sc.nextLine();
        while (!"End".equals(name)) {
            Buyer buyer = buyers.get(name);

            if (buyer != null) {
                buyer.buyFood();
            }

            name = sc.nextLine();
        }

        System.out.println(buyers.values().stream()
                .mapToInt(Buyer::getFood)
                .sum());
    }
}
