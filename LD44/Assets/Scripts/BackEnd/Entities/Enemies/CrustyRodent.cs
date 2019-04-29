using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustyRodent : Entity
{
    public CrustyRodent()
    {
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
        EntityArt = Resources.Load<Sprite>("EntityArt/furry_rodent_01");
        AttackDamage = 2;
    }
}
