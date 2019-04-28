using System;
using System.Linq;

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
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player P = Player.PlayerRef;
        List<Entity> Enemies = BattleManager.BattleManagerRef.Enemies;
        if (P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            foreach (Entity Enemy in Enemies)
            {
                Enemy.TakeHitDamage(AttackDamage);
            }
        }
    }
}
