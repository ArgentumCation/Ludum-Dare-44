using UnityEngine;

public class Punch : AttackCard
{
    public Punch()
    {
        NumTargets = 1;
        AttackDamage = 3;
        HealthCost = 1;
        Description = "Punch\n1 HP\nDeal 3 damage to a single target.";
        CardArt = Resources.Load<Sprite>("CardArt/punch");
    }
}
