using System;

public class HealingBeam : HealingCard
{
	public HealingBeam()
	{
        NumTargets = 1;
        AttackDamage = -6;
        HealthCost = 3;

        Description = "Healing Beam\n3 HP\nHeal 6 to a single target";

    }

}
