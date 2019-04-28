using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackCard : Card
{
    // Damage card will deal, should be negative to heal.
    public int AttackDamage;
    
    // Casts the card effect on all targets
    public override void Cast(IEnumerable<Entity> targets)
    {
        List<Entity> targetList = targets.ToList();
        
        Player p = Player.PlayerRef;
        if (p.CanCast(this) && targetList.Count == NumTargets)
        {
            p.TakeCastDamage(HealthCost);

            foreach (Entity target in targetList)
            {
                target.TakeHitDamage(DamageValue());
            }
        }
    }
    
    // returns card attack damage
    protected virtual int DamageValue()
    {
        return AttackDamage;
    }

    public override CardType GetCardType()
    {
        return CardType.AttackCard;
    }
}
