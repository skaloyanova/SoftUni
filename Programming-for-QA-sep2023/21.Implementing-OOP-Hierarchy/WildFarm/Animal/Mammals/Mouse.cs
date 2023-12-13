namespace WildFarm.Animal;
using WildFarm.Food;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("Squeak"); ;
    }

    public override void FeedAnimal(Food food)
    {
        //Mice eat vegetables and fruits
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.1 * food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
