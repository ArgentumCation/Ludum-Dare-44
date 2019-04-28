using UnityEngine;

public class TestEnemy : Entity
{
    public TestEnemy()
    {
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
        EntityArt = Resources.Load<Sprite>("EntityArt/testsprite");
    }
}
