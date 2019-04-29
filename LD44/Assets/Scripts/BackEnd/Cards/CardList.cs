using System;
using Random = UnityEngine.Random;

public class CardList
{
    public static Type[] Cards =
    {
        typeof(ComboStrike),
        typeof(HealingBeam),
        typeof(Jab),
        typeof(HammerThrust),
        typeof(Punch),
        typeof(BloodBeam),
        typeof(Assassination),
        typeof(DoubleStrike),
        typeof(LeechingArrow),
        typeof(LesserHealing),
        typeof(RoundhouseKick),
        typeof(Punch)
    };

    public static Type GetRandomCard()
    {
        return Cards[Random.Range(0, Cards.Length - 1)];
    }
}
