using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoarseHorse : Entity
{
    public HoarseHorse()
    {
        MaxHealth = 5;
        CurrentHealth = MaxHealth;
        EntityArt = Resources.Load<Sprite>("EntityArt/furry_horse_01");
        AttackDamage = 5;
    }

}
