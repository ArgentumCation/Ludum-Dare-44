using System;

public class Jab : AttackCard
{
	public Jab()
    {
        NumTargets = 1;
        AttackDamage = 2;
        HealthCost = 0;
        Description = "Jab\n0 HP\nDeal 2 damage to a single target.";

    }
}
