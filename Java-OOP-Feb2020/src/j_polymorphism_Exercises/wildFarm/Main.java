package j_polymorphism_Exercises.wildFarm;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        List<Animal> animals = new ArrayList<>();

        String firstLine = sc.nextLine();

        while (!"End".equals(firstLine)) {

            Animal animal = createAnimal(firstLine);

            String secondLine = sc.nextLine();

            Food food = createFood(secondLine);

            if (animal != null) {
                animals.add(animal);
                animal.makeSound();

                if (food != null) {
                    try {
                        animal.eat(food);
                    } catch (IllegalStateException e) {
                        System.out.println(e.getMessage());
                    }
                }
            }

            firstLine = sc.nextLine();
        }

        //print all animals
        for (Animal animal : animals) {
            System.out.println(animal.toString());
        }

    }

    private static Food createFood(String secondLine) {
        String[] split = secondLine.split("\\s+");

        String foodType = split[0];
        int foodQuantity = Integer.parseInt(split[1]);

        switch (foodType) {
            case "Vegetable":
                return new Vegetable(foodQuantity);
            case "Meat":
                return new Meat(foodQuantity);
            default:
                return null;
        }
    }

    private static Animal createAnimal(String firstLine) {
        String[] split = firstLine.split("\\s+");

        String animalType = split[0];
        String animalName = split[1];
        double animalWeight = Double.parseDouble(split[2]);
        String animalLivingRegion = split[3];

        switch (animalType) {
            case "Cat":
                String catBreed = split[4];
                return new Cat(animalType, animalName, animalWeight, animalLivingRegion, catBreed);
            case "Tiger":
                return new Tiger(animalType, animalName, animalWeight, animalLivingRegion);
            case "Mouse":
                return new Mouse(animalType, animalName, animalWeight, animalLivingRegion);
            case "Zebra":
                return new Zebra(animalType, animalName, animalWeight, animalLivingRegion);
            default:
                return null;
        }
    }
}
