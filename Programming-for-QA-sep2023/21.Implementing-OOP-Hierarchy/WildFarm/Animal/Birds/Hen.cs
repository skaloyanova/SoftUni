using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Hens eat everything
        this.FoodEaten += quantity;
        this.Weight += 0.35 * quantity;

    }
}
