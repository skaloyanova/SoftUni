using System.Collections.Generic;
using System.Linq;
using ExerciseOopHierarchy.Menu;

namespace ExerciseOopHierarchy;

public class Order
{
    private List<MenuItem> _items = new();
    public IReadOnlyCollection<MenuItem> Items => this._items.AsReadOnly();

    public void AddItem(MenuItem item)
    {
        this._items.Add(item);
    }

    public decimal GetTotal()
    {
        return this._items.Sum(i => i.Price);
    }
}
