using System;

public class Assassination : AttackCard
{
	public Assassination()
	{
        NumTargets = 1;
        AttackDamage = 0;
        HealthCost = 5;
        Description = "Assassination\n5 HP\nDestroy a single target with 25% or less health remaining.";
    }

    // Casts the card effect on an enemy with 25% or less health
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player P = Player.PlayerRef;
        List<Entity> enemies = targets.ToList();
        if (enemies.Count == 1 && enemies[0].CurrentHealth <= enemies[0].MaxHealth/4 - 1 && P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            enemies[0].TakeHitDamage(enemies[0].CurrentHealth);
        }
    }
}
