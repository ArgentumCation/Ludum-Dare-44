using System;
using Random = UnityEngine.Random;

public class EnemyList
{
    public static Type[] Enemies =
    {
        typeof(WetWolf),
        typeof(HoarseHorse),
        typeof(CrustyRodent)
    };

    public static Type GetRandomEnemy()
    {
        return Enemies[Random.Range(0, Enemies.Length)];
    }
}
