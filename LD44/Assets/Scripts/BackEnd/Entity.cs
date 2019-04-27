using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    // whether or not entity or friendly
    public bool IsFriendly;

    // entity health remaining
    public int CurrentHealth;

    // max entity health
    public int MaxHealth;

    // Current buffs on entity
    public List<Buff> Buffs;

    // returns current entity health
    public int GetHealth()
    {
        return CurrentHealth;
    }
    
    // kills entity
    public void Die()
    {

    }

    // changes entity health
    public void Damage(int damage)
    {
        CurrentHealth -= damage;
    }


}
