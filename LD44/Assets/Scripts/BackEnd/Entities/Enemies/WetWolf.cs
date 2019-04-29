using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetWolf : Entity
{
    public WetWolf()
    {
        MaxHealth = 15;
        CurrentHealth = MaxHealth;
        EntityArt = Resources.Load<Sprite>("EntityArt/furry_canine_01");
        AttackDamage = 1;
    }
}
