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

    // Damage card deals
    public int AttackDamage;

    // Casts the card effect on all targets
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
    
    // returns card attack damage
    private int damageValue()
    {
        return AttackDamage;
    }
}
