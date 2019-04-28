using System.Collections.Generic;

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
    public override void Cast(List<Entity> enemies)
    {
        Player P = Player.PlayerRef;
        if (enemies.Count == 1 && P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            enemies[0].TakeHitDamage(AttackDamage);
            P.TakeHitDamage(-1 * AttackDamage);
        }
    }
}
