using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void FeedAnimal(Food food, int quantity)
    {
        //Cats eat vegetables and meat
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
        {
            this.FoodEaten += quantity;
            this.Weight += 0.3 * quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
