package d_inheritance_Exercises.animals;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Animal> animals = new ArrayList<>();

        while (true) {
            String animalType = sc.nextLine().trim();

            if ("Beast!".equals(animalType)) {
                break;
            }

            String[] input = sc.nextLine().split("\\s+");

            if (!isValidInput(animalType, input)) {
                System.out.println("Invalid input!");
                continue;
            }

            String name = input[0];
            int age = Integer.parseInt(input[1]);
            String gender = "";
            if (input.length > 2) {
                gender = input[2];
            }

            Animal animal = createAnimalObject(animalType, name, age, gender);
            animals.add(animal);
        }

        for (Animal animal : animals) {
            System.out.println(animal);
        }
    }

    private static Animal createAnimalObject(String animalType, String name, int age, String gender) {
        switch (animalType) {
            case "i_polymorphism_Lab.animals.j_polymorphism_Exercises.wildFarm.Cat":
                return new Cat(name, age, gender);
            case "i_polymorphism_Lab.animals.Dog":
                return new Dog(name, age, gender);
            case "Frog":
                return new Frog(name, age, gender);
            case "Kitten":
                return new Kitten(name, age);
            case "Tomcat":
                return new Tomcat(name, age);
        }
        return null;
    }

    private static boolean isValidInput(String animalType, String[] input) {
        int paramCount = input.length;
        String age = input[1];
        String gender = "";

        if (paramCount > 2) {
            gender = input[2];
        }

        return isValidParamCount(animalType, paramCount)
                && isValidAge(age)
                && isValidGender(animalType, gender);
    }

    private static boolean isValidGender(String animalType, String gender) {
        if (animalType.equals("Kitten") || animalType.equals("Tomcat")) {
            return true;
        } else {
            return ("Female").equals(gender) || ("Male").equals(gender);
        }
    }

    private static boolean isValidParamCount(String animalType, int paramCount) {
        return paramCount >= 3 ||
                (paramCount == 2 && (animalType.equals("Kitten") || animalType.equals("Tomcat")));
    }

    private static boolean isValidAge(String age) {
        int ageInt;

        try {
            ageInt = Integer.parseInt(age);
        } catch (Exception e) {
            return false;
        }

        return ageInt > 0;
    }
}
