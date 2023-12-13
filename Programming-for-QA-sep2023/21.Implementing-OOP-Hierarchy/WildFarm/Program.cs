using WildFarm.Animal;
using WildFarm.Food;

List<Animal> animals = new();

string command = Console.ReadLine();

while (command != "End")
{
    string[] split = command.Split();

    //even lines (starting from 0) will contain information about an animal in format:
    // Birds      -> "{Type} {Name} {Weight} {WingSize}"
    // Mice, Dogs -> "{Type} {Name} {Weight} {LivingRegion}"
    // Felines    -> "{Type} {Name} {Weight} {LivingRegion} {Breed}"

    string type = split[0];
    string name = split[1];
    double weight = double.Parse(split[2]);

    Animal animal = type switch
    {
        "Owl" => new Owl(name, weight, double.Parse(split[3])),
        "Hen" => new Hen(name, weight, double.Parse(split[3])),
        "Dog" => new Dog(name, weight, split[3]),
        "Mouse" => new Mouse(name, weight, split[3]),
        "Cat" => new Cat(name, weight, split[3], split[4]),
        "Tiger" => new Tiger(name, weight, split[3], split[4]),
        _ => throw new ArgumentException("Invalid animal type!")
    };

    animals.Add(animal);


    //odd lines will contain information about a piece of food that should be given to that animal
    command = Console.ReadLine();
    split = command.Split();

    //{FoodType} {quantity}
    string foodType = split[0];
    int quantity = int.Parse(split[1]);

    Food food = foodType switch
    {
        "Vegetable" => new Vegetable(quantity),
        "Fruit" => new Fruit(quantity),
        "Meat" => new Meat(quantity),
        "Seeds" => new Seeds(quantity),
        _ => throw new ArgumentException()
    };

    animal.AskForFood();
    animal.FeedAnimal(food);

    command = Console.ReadLine();
}

Console.WriteLine(String.Join(Environment.NewLine, animals));