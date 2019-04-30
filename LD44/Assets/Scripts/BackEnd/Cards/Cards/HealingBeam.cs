using UnityEngine;

public class HealingBeam : HealingCard
{
	public HealingBeam()
	{
        NumTargets = 1;
        AttackDamage = -9;
        HealthCost = 3;

        Description = "Healing Beam\n3 HP\nHeal 9 to a single target";
        CardArt = Resources.Load<Sprite>("CardArt/healing_beam");
    }

}
