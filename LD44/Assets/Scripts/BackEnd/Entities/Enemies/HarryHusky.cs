using UnityEngine;

public class HarryHusky : Entity
{
    public HarryHusky()
    {
        MaxHealth = 30;
        CurrentHealth = MaxHealth;
        EntityArt = Resources.Load<Sprite>("EntityArt/harry");
        AttackDamage = 5;
    }
}
