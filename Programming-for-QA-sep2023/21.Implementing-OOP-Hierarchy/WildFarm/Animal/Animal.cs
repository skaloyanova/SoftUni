namespace WildFarm.Animal;
using WildFarm.Food;

public abstract class Animal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public abstract void AskForFood();

    public abstract void FeedAnimal(Food food);

}
