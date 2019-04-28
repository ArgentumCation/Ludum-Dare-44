using System.Collections.Generic;

public class BloodBeam : AttackCard
{
	public BloodBeam()
	{
        NumTargets = 3;
        AttackDamage = 2;
        HealthCost = 4;
        Description = "Blood Beam\n4 HP\nDeal 2 damage to all enemies.";
    }

    // Casts the card effect on all enemies
    public override void Cast(List<Entity> enemies)
    {
        Player P = Player.PlayerRef;
        if (P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            foreach (Entity enemy in enemies)
            {
                enemy.TakeHitDamage(AttackDamage);
            }
        }
    }
}
