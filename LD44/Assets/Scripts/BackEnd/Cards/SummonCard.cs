using System;
using System.Collections.Generic;

public class SummonCard : Card
{
    private Type _spawnedEntity;
    
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
            p.TakeCastDamage(HealthCost);
            Player.Team.Add((Entity) Activator.CreateInstance(_spawnedEntity));
        }

    }

    public override CardType GetCardType()
    {
        return CardType.SummonCard;
    }
}
