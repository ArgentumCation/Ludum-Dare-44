using UnityEngine;

public class FountainRoom : Room
{
    public override void Enter()
    {
        Object.Instantiate(FountainMB.FountainPrefab);
    }
}
