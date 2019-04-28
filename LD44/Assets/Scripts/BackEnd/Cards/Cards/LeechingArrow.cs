using System;
using System.Linq;

public class LeechingArrow : AttackCard
{
	public LeechingArrow()
	{
        NumTargets = 1;
        AttackDamage = 2;
        HealthCost = 2;
        Description = "Leeching Arrow\n2 HP\nDeal 2 damage, heal 4 damage.";
    }

    // Casts the card effect on a single target
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player P = Player.PlayerRef;
        List<Entity> enemies = targets.ToList();
        if (enemies.Count == 1 && P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            enemies[0].TakeHitDamage(AttackDamage);
            P.HitDamage(-1 * AttackDamage);
        }
    }
}
