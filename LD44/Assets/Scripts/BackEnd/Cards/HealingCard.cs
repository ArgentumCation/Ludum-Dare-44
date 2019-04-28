using System.Collections.Generic;
using System.Linq;

public class HealingCard : Card
{
    // Damage card will deal, should be negative to heal.
    public int AttackDamage;

    // Casts the card effect on all targets.
    public override void Cast(IEnumerable<Entity> targets)
    {
        List<Entity> targetList = targets.ToList();

        Player p = Player.PlayerRef;
        if (p.CanCast(this) && targetList.Count == NumTargets)
        {
            p.TakeCastDamage(HealthCost);

            foreach (Entity target in targetList)
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