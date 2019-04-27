using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private int health;

    private int attackDamage;

    public void Damage(int damage)
    {
        health -= damage;
    }
}
