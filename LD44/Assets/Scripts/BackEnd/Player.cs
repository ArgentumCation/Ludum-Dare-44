using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player PlayerRef;

    public List<Friendly> summons;

    public Artifact[] artifacts;

    public int CurrentHealth;

    public Player()
    {
        if(PlayerRef != null)
        {
            throw new System.Exception("Tried to make second player");
            
        }
        PlayerRef = this;
    }

    public void TakeCastDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void TakeHitDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public bool CanCast(int damage)
    {
        return damage < CurrentHealth;
    }
}
