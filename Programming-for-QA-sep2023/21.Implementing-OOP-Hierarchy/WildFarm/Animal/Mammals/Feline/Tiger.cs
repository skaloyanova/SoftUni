namespace WildFarm.Animal;
using WildFarm.Food;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override void FeedAnimal(Food food)
    {
        //Tigers eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 1 * food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
