using UnityEngine;

public class DoubleStrike : AttackCard
{
	public DoubleStrike()
	{
        NumTargets = 2;
        AttackDamage = 4;
        HealthCost = 3;
        Description = "Bloody Rampage\n3 HP\nDeal 4 damage to 2 targets.";
        CardArt = Resources.Load<Sprite>("CardArt/double_strike");
    }
}
