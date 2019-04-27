using System.Collections.Generic;

public class SummonCard : Card
{
    public SummonCard()
    {
        NumTargets = 0;
        CanTargetFriendly = false;
    }

    // Casts the card effect;
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(this))
        {
            p.Damage(HealthCost);
            Player.Team.Add(new Friendly());
        }

    }

    protected virtual int HealAmount()
    {
        return 0;
    }
}
