namespace WildFarm.Animal;
using WildFarm.Food;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("Cluck");
    }

    public override void FeedAnimal(Food food)
    {
        //Hens eat everything
        this.FoodEaten += food.Quantity;
        this.Weight += 0.35 * food.Quantity;

    }
}
