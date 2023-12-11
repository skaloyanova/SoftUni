namespace Raiding.Models.Heroes;

public class Druid : Healer
{
    public Druid(string name) : base(name)
    {
        this.Power = 80;
    }

    public override int Power { get; }

    public override string CastAbility()
    {
        return base.CastAbility();
    }
}
