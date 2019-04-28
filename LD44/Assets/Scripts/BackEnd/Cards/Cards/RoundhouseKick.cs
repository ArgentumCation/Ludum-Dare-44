using UnityEngine;

public class RoundhouseKick : AttackCard
{
    public RoundhouseKick()
    {
        NumTargets = 1;
        AttackDamage = 8;
        HealthCost = 3;
        Description = "Furry Stomp\n3 HP\nDeal 3 damage to a single target.";
        CardArt = Resources.Load<Sprite>("CardArt/roundhouse_kick");
    }
}
