using System;
using Random = UnityEngine.Random;

public class EnemyList
{
    public static Type[] Enemies =
    {
        typeof(TestEnemy)
    };

    public static Type GetRandomEnemy()
    {
        return Enemies[Random.Range(0, Enemies.Length - 1)];
    }
}
