using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Tigers eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += quantity;
            this.Weight += 1 * quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
