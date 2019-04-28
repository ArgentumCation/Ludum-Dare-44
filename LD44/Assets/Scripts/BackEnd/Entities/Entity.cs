using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    // whether or not entity or friendly
    public bool IsFriendly;

    // entity health remaining
    public int CurrentHealth;

    // max entity health
    public int MaxHealth;

    // Current buffs on entity
    public List<Buff> Buffs;

    public Entity()
    {
        CurrentHealth = MaxHealth;
    }
    
    // kills entity
    public virtual void Die()
    {
        BattleManager.BattleManagerRef.Die(this);
    }

    // changes entity health
    public virtual void TakeHitDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
