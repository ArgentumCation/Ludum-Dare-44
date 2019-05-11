using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    // Current buffs on entity
    public List<Buff> Buffs = new List<Buff>();

    // max entity health
    public int MaxHealth;
    // entity health remaining
    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value < MaxHealth ? value : MaxHealth;
    }

    public int AttackDamage;

    // whether or not entity or friendly
    public bool IsFriendly;
    
    public Sprite EntityArt;

    public EntityMB MeEntityMB;

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
        float buffPercent = 0;
        foreach (Buff buff in Buffs)
            if (buff.Type == BuffType.DefenseBuff)
                buffPercent += buff.Amount;
        
        CurrentHealth -= Mathf.RoundToInt(Mathf.Max(damage * (1 - buffPercent / 100), 0));
        
        MeEntityMB.TakeDamage();
    }

    public virtual void Heal(int amount)
    {
        CurrentHealth += amount;
    }

    public int GetAttackDamage()
    {
        float buffPercent = 0;
        foreach (Buff buff in Buffs)
            if (buff.Type == BuffType.AttackBuff)
                buffPercent += buff.Amount;
        
        return Mathf.RoundToInt(Mathf.Max(AttackDamage * (1 + buffPercent / 100), 0));
    }
}
