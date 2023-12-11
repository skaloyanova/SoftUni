namespace Raiding.Models.Heroes;

public class Rogue : Fighter
{
    public Rogue(string name) : base(name)
    {
        this.Power = 80;
    }

    public override int Power { get; }
}
