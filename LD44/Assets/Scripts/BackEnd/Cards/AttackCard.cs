using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    // Damage card will deal, should be negative to heal.
    protected int AttackDamage;

    public AttackCard()
    {
        Description = "Attack Card\n0 HP\nDoes nothing.";
    }

    // Casts the card effect on all targets
    public override void Cast(List<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(this) && targets.Count == NumTargets)
        {
            p.TakeCastDamage(HealthCost);

            foreach (Entity target in targets)
                target.TakeHitDamage(DamageValue());
        }
    }

    // returns card attack damage
    protected virtual int DamageValue()
    {
        float buffPercent = 0;
        foreach (Buff buff in Player.PlayerRef.Buffs)
            if (buff.Type == BuffType.AttackBuff)
                buffPercent += buff.Amount;
        
        return Mathf.RoundToInt(Mathf.Max(AttackDamage * (1 + buffPercent / 100), 0));
    }

    public override CardType GetCardType()
    {
        return CardType.AttackCard;
    }
}
