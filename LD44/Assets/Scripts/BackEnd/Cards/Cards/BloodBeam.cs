using System.Collections.Generic;
using UnityEngine;

public class BloodBeam : AttackCard
{
	public BloodBeam()
	{
        AttackDamage = 5;
        HealthCost = 4;
        Description = "Blood Beam\n4 HP\nDeal 5 damage to all enemies.";
        CardArt = Resources.Load<Sprite>("CardArt/blood_beam");
    }

    // Casts the card effect on all enemies
    public override void Cast(List<Entity> targets)
    {
        List<Entity> enemies = BattleManager.BattleManagerRef.Enemies;
        Player p = Player.PlayerRef;
        if (p.CanCast(this))
        {
            p.TakeCastDamage(HealthCost);
            foreach (Entity enemy in enemies)
            {
                enemy.TakeHitDamage(AttackDamage);
            }
        }
    }
}
