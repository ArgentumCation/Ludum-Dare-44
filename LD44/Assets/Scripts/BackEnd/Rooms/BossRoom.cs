using System.Collections.Generic;
using UnityEngine;

public class BossRoom : BattleRoom
{
    public BossRoom()
    {
        CurrentRoom = this;

        Enemies = new List<Entity>();
        HarryHusky h = new HarryHusky();
        Enemies.Add(h);
        GameObject entityObject = Object.Instantiate(EntityMB.EntityPrefab, RoomMB.ActiveRoom.transform);
        EntityMB entityMb = entityObject.GetComponent<EntityMB>();
        entityMb.Init(h);
        entityObject.transform.localPosition = new Vector3(5.5f, 0, 0);
    }
}
