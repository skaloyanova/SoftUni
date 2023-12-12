using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Food;

public abstract class Food
{
    protected Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}
