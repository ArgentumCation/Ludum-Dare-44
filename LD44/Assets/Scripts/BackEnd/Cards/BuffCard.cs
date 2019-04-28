using System.Collections.Generic;

public class BuffCard : Card
{
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
            targets[0].Buffs.Add(new Buff(BuffType.AttackBuff, 0));
            p.TakeCastDamage(HealthCost);
        }
    }

    public override CardType GetCardType()
    {
        return CardType.BuffCard;
    }
}
