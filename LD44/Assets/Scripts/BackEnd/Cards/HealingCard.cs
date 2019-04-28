using System.Collections.Generic;
using System.Linq;

public class HealingCard : Card
{
    // Damage card will deal, should be negative to heal.
    public int AttackDamage;

    public HealingCard()
    {
        Description = "Healing Card\n0 HP\nDoes nothing.";
    }

    // Casts the card effect on all targets.
    public override void Cast(List<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(this) && targets.Count == NumTargets)
        {
            p.TakeCastDamage(HealthCost);

            foreach (Entity target in targets)
            {
                target.TakeHitDamage(HealingValue());
            }
        }
    }

    // returns the healing value.
    protected virtual int HealingValue()
    {
        return AttackDamage;
    }

    public override CardType GetCardType()
    {
        return CardType.HealingCard;
    }
}