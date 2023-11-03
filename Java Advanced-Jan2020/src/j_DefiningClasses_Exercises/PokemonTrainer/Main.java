package j_DefiningClasses_Exercises.PokemonTrainer;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        Map<String, Trainer> trainerAndPokemons = new LinkedHashMap<>();

        // read info about trainers and Pokemons
        String input = sc.nextLine();
        while (!"Tournament".equals(input)) {
            String[] tokens = input.split("\\s+");
            String tName = tokens[0];
            String pName = tokens[1];
            String pElement = tokens[2];
            int pHealth = Integer.parseInt(tokens[3]);

            if (trainerAndPokemons.containsKey(tName)) {
                trainerAndPokemons.get(tName).addPokemonToList(pName, pElement, pHealth);
            } else {
                trainerAndPokemons.put(tName, new Trainer(tName, pName, pElement, pHealth));
            }

            input = sc.nextLine();
        }

        // interact with Pokemons
        String elementCheck = sc.nextLine();    //Fire", "Water" or "Electricity"
        while (!"End".equals(elementCheck)) {
            for (Trainer trainer : trainerAndPokemons.values()) {
                trainer.pokemonElementCheck(elementCheck);
            }

            elementCheck = sc.nextLine();
        }

        // output
        trainerAndPokemons.values()
                .stream()
                .sorted((b1,b2) -> Integer.compare(b2.getBadges(), b1.getBadges()))
                .forEach(System.out::println);
    }
}
