using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Mice eat vegetables and fruits
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
        {
            this.FoodEaten += quantity;
            this.Weight += 0.1 * quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
