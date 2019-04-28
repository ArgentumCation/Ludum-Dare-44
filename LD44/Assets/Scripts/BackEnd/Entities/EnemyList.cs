using System;
using Random = UnityEngine.Random;

public class EnemyList
{
    public static Type[] Enemies =
    {
        typeof(TestEnemy)
    };

    public static Type GetRandomEntity()
    {
        return Enemies[Random.Range(0, Enemies.Length - 1)];
    }
}
