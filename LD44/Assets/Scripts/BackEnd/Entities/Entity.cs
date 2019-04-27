using System.Collections.Generic;

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
    
    // kills entity
    public virtual void Die()
    {

    }

    // changes entity health
    public virtual void Damage(int damage)
    {
        CurrentHealth -= damage;
    }


}
