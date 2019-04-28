using System;

public class HealingCyclone : HealingCard
{
    public HealingCyclone()
    {
        NumTargets = 0;
        AttackDamage = -10;
        HealthCost = 10;
        CanTargetFriendly = true;
        Description = "Healing Cyclone\n3 HP\nHeal 10 to all friendly allies";
    }


    // Casts the card effect on all friendly allies
    public override void Cast(IEnumerable<Entity> targets)
    {
        Player P = Player.PlayerRef;
        List<Entity> Friendlies = BattleManager.BattleManagerRef.Friendlies;
        if (P.CanCast(this) && Friendlies.Count > 1)
        {
            foreach (Entity target in Friendlies)
            {
                if (target != P)
                {
                    target.TakeHitDamage(AttackDamage);
                }
            }
        }
    }
}
