using System.Collections.Generic;

public class HealingCyclone : HealingCard
{
    public HealingCyclone()
    {
        NumTargets = 0;
        AttackDamage = -10;
        HealthCost = 10;
        Description = "Healing Cyclone\n3 HP\nHeal 10 to all friendly allies";
    }


    // Casts the card effect on all friendly allies
    public override void Cast(List<Entity> targets)
    {
        Player P = Player.PlayerRef;
        List<Entity> friendlies = BattleManager.BattleManagerRef.Friendlies;
        if (P.CanCast(this) && friendlies.Count > 1)
        {
            foreach (Entity target in friendlies)
            {
                if (target != P)
                {
                    target.TakeHitDamage(AttackDamage);
                }
            }
        }
    }
}
