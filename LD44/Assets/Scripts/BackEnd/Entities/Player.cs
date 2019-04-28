using System;
using System.Collections.Generic;

public class Player : Entity
{
    public static Player PlayerRef;

    public static List<Entity> Team;

    public Artifact[] Artifacts;

    public Player()
    {
        if (PlayerRef != null)
            throw new Exception("Tried to make second player");
        PlayerRef = this;

        MaxHealth = 30;
        CurrentHealth = MaxHealth;

        Team = new List<Entity> {this};
        Buffs = new List<Buff>();
    }

    public bool CanCast(Card c)
    {
        return c.HealthCost < CurrentHealth;
    }

    public void TakeCastDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public override void TakeHitDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void UseFountain()
    {
        CurrentHealth = MaxHealth;
        Team = new List<Entity> {this};
        Buffs.Clear();
        Deck.Draws.AddRange(Deck.Discards);
        Deck.Shuffle(Deck.Draws);
    }
}
