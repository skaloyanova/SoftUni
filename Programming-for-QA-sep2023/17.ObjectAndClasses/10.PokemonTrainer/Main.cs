using _10.PokemonTrainer;

List<Trainer> trainers = new();

// CREATE TRAINERS with Pokemons

string command = Console.ReadLine();

while(command != "Tournament")
{
    // Input format until until command "Tournament" is received: {trainerName} {pokemonName} {pokemonElement} {pokemonHealth}

    string[] data = command.Split();

    var pokemon = new Pokemon(data[1], data[2], int.Parse(data[3]));

    string trainerName = data[0];
    var trainer = trainers.Find(t => t.Name == trainerName);

    if (trainer == null)
    {
        trainer = new Trainer(trainerName);
        trainers.Add(trainer);
    }

    trainer.Pokemons.Add(pokemon);
    
    command = Console.ReadLine();
}

// FIGHT
// For every command, you must check if a trainer has at least 1 pokemon with the given element.
// If he does, he receives 1 badge. Otherwise, all of his pokemon lose 10 health.
// If a pokemon falls to 0 or less health, he dies and must be deleted from the trainer's collection.

string element = Console.ReadLine();

while (element != "End")
{
    foreach (Trainer trainer in trainers)
    {
        if (trainer.Pokemons.Any(p => p.Element == element))
        {
            trainer.NumberOfBadges++;
        }
        else
        {
            for (int i = 0; i < trainer.Pokemons.Count; i++)
            {
                Pokemon currentPokemon = trainer.Pokemons[i];
                currentPokemon.Health -= 10;

                if (currentPokemon.Health <= 0)
                {
                    trainer.Pokemons.Remove(currentPokemon);
                    i--;
                }
            }
        } 
    }

    element = Console.ReadLine();
}

// Print all of the trainers, sorted by the number of badges they have in descending order.
// If two trainers have the same amount of badges, they should be sorted by order of appearance in the input

trainers
    .OrderByDescending(t => t.NumberOfBadges)
    .ToList()
    .ForEach(t => Console.WriteLine(t));

