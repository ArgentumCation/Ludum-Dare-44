using System.Collections.Generic;

public class BloodBeam : AttackCard
{
	public BloodBeam()
	{
        AttackDamage = 5;
        HealthCost = 4;
        Description = "Blood Beam\n4 HP\nDeal 5 damage to all enemies.";
    }

    // Casts the card effect on all enemies
    public override void Cast(List<Entity> targets)
    {
        List<Entity> enemies = BattleManager.BattleManagerRef.Enemies;
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
