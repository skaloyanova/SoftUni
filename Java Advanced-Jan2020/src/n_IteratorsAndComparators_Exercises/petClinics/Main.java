package n_IteratorsAndComparators_Exercises.petClinics;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());
        Map<String, Pet> pets = new HashMap<>();
        Map<String, Clinic> clinics = new HashMap<>();

        while (n-- > 0) {
            String[] tokens = sc.nextLine().split("\\s+");

            switch (tokens[0]) {
                case "Create":
                    create(pets, clinics, tokens);
                    break;
                case "Add":
                    String petName = tokens[1];
                    String clinicNameA = tokens[2];
                    if (pets.containsKey(petName) && clinics.containsKey(clinicNameA)) {
                        System.out.println(clinics.get(clinicNameA).addPet(pets.get(petName)));
                    } else {
                        System.out.println("Invalid Operation!");
                    }
                    break;
                case "Release":
                    String clinicNameR = tokens[1];
                    if (clinics.containsKey(clinicNameR)) {
                        System.out.println(clinics.get(clinicNameR).releasePet());
                    } else {
                        System.out.println("Invalid Operation!");
                    }
                    break;
                case "HasEmptyRooms":
                    String clinicNameE = tokens[1];
                    System.out.println(clinics.get(clinicNameE).HasEmptyRooms());
                    break;
                case "Print":
                    String clinicNameP = tokens[1];
                    if (tokens.length == 2) {
                        clinics.get(clinicNameP).print();
                    } else {
                        clinics.get(clinicNameP).print(Integer.parseInt(tokens[2]));
                    }
                    break;
            }
        }
    }

    private static void create(Map<String, Pet> pets, Map<String, Clinic> clinics, String[] tokens) {
        if ("Pet".equals(tokens[1])) {
            Pet pet = new Pet(tokens[2], Integer.parseInt(tokens[3]), tokens[4]);
            pets.put(tokens[2], pet);
        } else if ("Clinic".equals(tokens[1])) {
            try {
                Clinic clinic = new Clinic(tokens[2], Integer.parseInt(tokens[3]));
                clinics.put(tokens[2], clinic);
            } catch (IllegalArgumentException ex) {
                System.out.println("Invalid Operation!");
            }
        }
    }
}
