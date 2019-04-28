using System.Collections.Generic;

public abstract class Entity
{
    // Current buffs on entity
    public List<Buff> Buffs;

    // entity health remaining
    public int CurrentHealth;

    // whether or not entity or friendly
    public bool IsFriendly;

    // max entity health
    public int MaxHealth;

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
