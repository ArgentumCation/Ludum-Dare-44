using System.Collections.Generic;

public class Card
{
    // Health player will lose or gain after casting
    public int HealthCost;

    // Whether or not card can traget friendly entities
    public bool CanTargetFriendly;

    // Amount of entities card can target
    public int NumTargets;

    // Casts the card effect;
    public virtual void Cast(IEnumerable<Entity> targets)
    {
    }
}
