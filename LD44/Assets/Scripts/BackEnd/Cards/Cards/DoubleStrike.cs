using System;

public class DoubleStrike : AttackCard
{
	public DoubleStrike()
	{
        NumTargets = 2;
        AttackDamage = 4;
        HealthCost = 3;
        Description = "Double Strike\n3 HP\nDeal 4 damage to 2 targets.";
    }
}
