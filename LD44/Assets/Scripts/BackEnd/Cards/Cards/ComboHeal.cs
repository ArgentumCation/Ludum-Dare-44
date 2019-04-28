using System.Collections.Generic;

public class ComboHeal : HealingCard
{
	public ComboHeal()
	{
        NumTargets = 0;
        AttackDamage = -5;
        HealthCost = 2;
        Description = "Combo Heal\n2 HP\nHeal 5 to player. If below 50% health afterwards, heal 5 more.";
    }

    // Casts the card effect on the player
    public override void Cast(List<Entity> targets)
    {
        Player P = Player.PlayerRef;
        if (P.CanCast(this))
        {
            P.TakeCastDamage(HealthCost);
            P.TakeHitDamage(AttackDamage);
            if(P.CurrentHealth <= P.MaxHealth / 2 + 1)
            {
                P.TakeHitDamage(AttackDamage);
            }
        }
    }

}
