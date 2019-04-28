using System.Collections.Generic;

public class BuffCard : Card
{
    protected Buff MyBuff;

    public BuffCard()
    {
        Description = "Buff Card\n0 HP\nDoes nothing.";
    }

    // Casts the card effect
    public override void Cast(List<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(this))
        {
            targets[0].Buffs.Add(GetBuff());
            p.TakeCastDamage(HealthCost);
        }
    }

    public override CardType GetCardType()
    {
        return CardType.BuffCard;
    }

    protected virtual Buff GetBuff()
    {
        return MyBuff;
    }
}
