using UnityEngine;

public class LesserHealing : HealingCard
{
	public LesserHealing()
	{
        NumTargets = 1;
        AttackDamage = -4;
        HealthCost = 0;
        Description = "Small Blood Transfusion\n0 HP\nHeal 4 HP to a single friendly target";
        CardArt = Resources.Load<Sprite>("CardArt/lesser_healing");
    }

}
