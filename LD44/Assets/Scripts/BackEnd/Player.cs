using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    static Player PlayerRef;

    public Artifact[3] artifacts;

    private int health;

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
        health -= damage;
    }

    public void TakeHitDamage(int damage)
    {
        health -= damage;
    }
}
