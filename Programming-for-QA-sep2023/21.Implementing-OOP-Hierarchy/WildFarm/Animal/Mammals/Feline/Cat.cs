namespace WildFarm.Animal;
using WildFarm.Food;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void AskForFood()
    {
        Console.WriteLine("Meow"); ;
    }

    public override void FeedAnimal(Food food)
    {
        //Cats eat vegetables and meat
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.3 * food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
