package j_DefiningClasses_Exercises.PokemonTrainer;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

public class Trainer {
    private String trainerName;
    private int badges;
    private List<Pokemon> pokemons = new ArrayList<>();

    public Trainer(String trainerName, String pokemonName, String pokemonElement, int pokemonHealth) {
        this.trainerName = trainerName;
        this.badges = 0;
        this.pokemons.add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
    }

    public int getBadges() {
        return badges;
    }

    public void addPokemonToList(String pokemonName, String pokemonElement, int pokemonHealth) {
        this.pokemons.add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
    }

    public void pokemonElementCheck(String pokemonElement) {
        for (Pokemon pokemon : pokemons) {
            if (pokemon.getPokemonElement().equals(pokemonElement)) {
                this.badges++;
                return;
            }
        }

        for (int i = 0; i < pokemons.size(); i++) {
            Pokemon current = pokemons.get(i);
            current.setPokemonHealth(current.getPokemonHealth() - 10);
            if (current.getPokemonHealth() <= 0) {
                pokemons.remove(current);
                i--;
            }
        }
    }

    @Override
    public String toString() {
        return this.trainerName + " " + this.badges + " " + this.pokemons.size();
    }
}
