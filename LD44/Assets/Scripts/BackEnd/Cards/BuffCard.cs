using System.Collections.Generic;

public class BuffCard : Card
{
    // Health player will lose or gain after casting
    public int HealthCost;

    public BuffCard()
    {
        
    }

    // Casts the card effect
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(this))
        {
            p.Buffs.Add(new Buff());
            p.TakeCastDamage(HealthCost);
        }
    }

    public override CardType GetCardType()
    {
        return CardType.BuffCard;
    }
}
