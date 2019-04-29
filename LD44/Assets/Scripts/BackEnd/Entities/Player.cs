using System;
using System.Collections.Generic;
using UnityEngine;

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
        EntityArt = Resources.Load<Sprite>("EntityArt/player");

        Team = new List<Entity> {this};
        Buffs = new List<Buff>();
        // TODO apply artifact buffs
    }

    public bool CanCast(Card c)
    {
        return c.HealthCost < CurrentHealth;
    }

    public void TakeCastDamage(int damage)
    {
        
        float buffPercent = 0;
        foreach (Buff buff in Buffs)
            if (buff.Type == BuffType.CostBuff)
                buffPercent += buff.Amount;
        
        CurrentHealth -= Mathf.RoundToInt(Mathf.Max(damage * (1 - buffPercent / 100), 0));
    }

    public void UseFountain()
    {
        CurrentHealth = MaxHealth;
        Team = new List<Entity> {this};
        Buffs.Clear();
        // TODO apply artifact buffs
        Deck.Draws.AddRange(Deck.Discards);
        Deck.Shuffle(Deck.Draws);
    }
}
