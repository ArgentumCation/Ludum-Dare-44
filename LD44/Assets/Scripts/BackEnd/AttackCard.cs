using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackCard : Card
{

    // Health player will lose or gain after casting
    public int HealthCost;

    // Whether or not card can traget friendly entities
    public bool CanTargetFriendly;

    // Amount of entities card can target
    public int NumTargets;

    public int AttackDamage;

    // Casts the card effect;
    // Casts the card effect;
    public void Cast(IEnumerable<Entity> targets)
    {
        List<Entity> targetList = targets.ToList();
        
        if(targetList.Count == NumTargets)
        {
            foreach(Entity target in targetList)
            {
                target.Damage(damageValue());
            }
        }
    }

    private int damageValue()
    {
        return AttackDamage;
    }
}
