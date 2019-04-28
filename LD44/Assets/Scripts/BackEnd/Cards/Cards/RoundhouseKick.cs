using System;

public class RoundhouseKick : AttackCard
{
    public RoundhouseKick()
    {
        NumTargets = 1;
        AttackDamage = 8;
        HealthCost = 3;
        Description = "Roundhouse Kick\n3 HP\nDeal 3 damage to a single target.";

    }
}
