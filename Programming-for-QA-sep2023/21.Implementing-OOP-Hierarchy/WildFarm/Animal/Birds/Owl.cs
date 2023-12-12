using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Owls eat only meat
        if (food.GetType().Name == "Meat")
        {
            this.FoodEaten += quantity;
            this.Weight += 0.25 * quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
