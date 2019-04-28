using System.Collections.Generic;

public abstract class Card
{
    public string Description = "Card\n0 HP\nDoes nothing.";

    // Health player will lose or gain after casting
    public int HealthCost = 0;

    // Amount of entities card can target
    public int NumTargets = 1;

    // Casts the card effect;
    public abstract void Cast(List<Entity> targets);

    public abstract CardType GetCardType();
}
