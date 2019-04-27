using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealingCard : Card
{
    // Start is called before the first frame update

    // Health player will lose or gain after casting
    public int HealthCost;

    // Whether or not card can traget friendly entities
    public bool CanTragetFriendly;

    // Amount of entities card can target
    public int NumTargets;

    // Damage card will deal, should be negative to heal.
    public int AttackDamage;

    // Casts the card effect on all targets.
    public void Cast(IEnumerable<Entity> targets)
    {
        List<Entity> targetList = targets.ToList();

        if (targetList.Count == NumTargets)
        {
            foreach (Entity target in targetList)
            {
                target.Damage(HealingValue());
            }
        }
    }

    // returns the healing value.
    private int HealingValue()
    {
        return AttackDamage;
    }



}
