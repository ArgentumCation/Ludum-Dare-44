using UnityEngine;

public class Jab : AttackCard
{
	public Jab()
    {
        NumTargets = 1;
        AttackDamage = 2;
        HealthCost = 0;
        Description = "Dagger\n0 HP\nDeal 2 damage to a single target.";
        CardArt = Resources.Load<Sprite>("CardArt/jab");

    }
}
