using System.Collections.Generic;

public class AttackCard : Card
{
    // Damage card will deal, should be negative to heal.
    public int AttackDamage;

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
        return AttackDamage;
    }

    public override CardType GetCardType()
    {
        return CardType.AttackCard;
    }
}
