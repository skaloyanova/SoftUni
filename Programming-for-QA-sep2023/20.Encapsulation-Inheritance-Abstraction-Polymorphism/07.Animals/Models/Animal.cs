namespace Animals.Models;

public abstract class Animal
{
    private string _name;
    private string _favoriteFood;

    //public string Name { get { return _name; } }
    //public string FavoriteFood {  get { return _favoriteFood; } }

    protected Animal(string name, string favoriteFood)
    {
        this._name = name;
        this._favoriteFood = favoriteFood;
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this._name} and my fovourite food is {this._favoriteFood}";
    }
}
