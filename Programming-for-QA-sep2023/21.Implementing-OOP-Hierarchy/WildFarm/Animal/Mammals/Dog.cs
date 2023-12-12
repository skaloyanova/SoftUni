using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Dogs eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += quantity;
            this.Weight += 0.4 * quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
