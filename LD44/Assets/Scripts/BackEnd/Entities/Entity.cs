using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    // Current buffs on entity
    public List<Buff> Buffs;

    // entity health remaining
    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value < MaxHealth ? value : MaxHealth;
    }

    // whether or not entity or friendly
    public bool IsFriendly;

    // max entity health
    public int MaxHealth;

    public Sprite EntityArt;

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
