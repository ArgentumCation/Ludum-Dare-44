using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    // entity health remaining
    private int health;

    // max entity health
    [SerializeField] public int MaxHealth;

    // Current buffs on entity
    public List<Buff> Buffs;


    // returns current entity health
    public int GetHealth()
    {
        return health;
    }
    
    // kills entity
    public void Die()
    {

    }

    // changes entity health
    public void Damage(int damage)
    {
        health -= damage;
    }


}
