using System.Collections.Generic;

public class SummonCard : Card
{
    // Health player will lose or gain after casting
    public int HealthCost;

    // Whether or not card can traget friendly entities
    public bool CanTargetFriendly;

    // Casts the card effect;
    public void Cast(IEnumerable<Entity> targets)
    {
        Player p = Player.PlayerRef;
        if (p.CanCast(HealthCost))
        {
            p.Damage(HealthCost);
            p.summons.Add(new Friendly());
        }

    }
}
