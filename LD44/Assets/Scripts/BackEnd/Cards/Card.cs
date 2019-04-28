using System;
using System.Collections.Generic;

public class Card
{
    // Health player will lose or gain after casting
    public int HealthCost;

    // Amount of entities card can target
    public int NumTargets;

    public string Description;

    // Casts the card effect;
    public virtual void Cast(IEnumerable<Entity> targets)
    {
    }

    public virtual CardType GetCardType()
    {
        throw new NotImplementedException("Called Card.CardType instead of on a subclass'");
    }
}
