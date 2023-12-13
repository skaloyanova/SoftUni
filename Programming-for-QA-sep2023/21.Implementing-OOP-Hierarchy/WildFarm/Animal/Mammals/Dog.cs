namespace WildFarm.Animal;
using WildFarm.Food;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("Woof!");
    }

    public override void FeedAnimal(Food food)
    {
        //Dogs eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.4 * food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
