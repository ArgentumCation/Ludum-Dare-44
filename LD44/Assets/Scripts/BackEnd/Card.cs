﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    // Start is called before the first frame update

    // Health player will lose or gain after casting
    public int HealthCost;

    // Whether or not card can traget friendly entities
    public bool CanTragetFriendly;

    // Amount of entities card can target
    public int NumTargets;

    // Casts the card effect;
    public void Cast(List<Entity> targets)
    {
    }
}
