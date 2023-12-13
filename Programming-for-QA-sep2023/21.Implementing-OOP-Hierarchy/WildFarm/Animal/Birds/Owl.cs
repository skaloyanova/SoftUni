namespace WildFarm.Animal;
using WildFarm.Food;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void FeedAnimal(Food food)
    {
        //Owls eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.25 * food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
