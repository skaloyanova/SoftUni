package h_interfacesAndAbstraction_Exercises.birthdayCelebrations;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Birthable> citizensAndPetsList = new ArrayList<>();

        String line = sc.nextLine();

        while (!"End".equals(line)) {
            String[] split = line.split("\\s+");

            String type = split[0];

            switch (type) {
                case "h_interfacesAndAbstraction_Exercises.birthdayCelebrations.h_interfacesAndAbstraction_Exercises.multipleImplFoodShortage.Citizen":
                    Citizen citizen = createCitizen(split);
                    citizensAndPetsList.add(citizen);
                    break;
                case "h_interfacesAndAbstraction_Exercises.birthdayCelebrations.Robot":
                    Robot robot = createRobot(split);
                    break;
                case "h_interfacesAndAbstraction_Exercises.birthdayCelebrations.Pet":
                    Pet pet = createPet(split);
                    citizensAndPetsList.add(pet);
                    break;
            }

            line = sc.nextLine();
        }

        String year = sc.nextLine();

        citizensAndPetsList.stream()
                .filter(c -> c.getBirthDate().endsWith(year))
                .forEach(c -> {
                    System.out.println(c.getBirthDate());
                });
    }


    private static Pet createPet(String[] split) {
        // "h_interfacesAndAbstraction_Exercises.birthdayCelebrations.Pet <name> <birthdate>" for pets
        String name = split[1];
        String birthdate = split[2];

        return new Pet(name, birthdate);
    }

    private static Robot createRobot(String[] split) {
        //"h_interfacesAndAbstraction_Exercises.birthdayCelebrations.Robot <model> <id>" for robots
        String model = split[1];
        String id = split[2];

        return new Robot(id, model);
    }

    private static Citizen createCitizen(String[] split) {
        //"h_interfacesAndAbstraction_Exercises.birthdayCelebrations.h_interfacesAndAbstraction_Exercises.multipleImplFoodShortage.Citizen <name> <age> <id> <birthdate>" for citizens
        String name = split[1];
        int age = Integer.parseInt(split[2]);
        String id = split[3];
        String birthdate = split[4];

        return new Citizen(name, age, id, birthdate);
    }
}
