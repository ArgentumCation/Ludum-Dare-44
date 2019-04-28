using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BattleRoom : Room
{
    public List<Entity> Enemies;
    
    public BattleRoom()
    {
        CurrentRoom = this;
        
        Enemies = new List<Entity>();
        
        int n = Random.Range(1, 4);
        for (int i = 0; i < n; i++)
        {
            Entity e = (Entity) Activator.CreateInstance(EnemyList.GetRandomEntity());
            Enemies.Add(e);
            GameObject entityObject = Object.Instantiate(EntityMB.EntityPrefab, RoomMB.ActiveRoom.transform);
            EntityMB entityMb = entityObject.GetComponent<EntityMB>();
            entityMb.Init(e);
            entityObject.transform.localPosition = new Vector3( 2 + i * 1.7f, 0, 0);
        }
    }
    
    public override void Enter()
    {
        GameObject gameObject = new GameObject();
        BattleMB battleMb = gameObject.AddComponent<BattleMB>();
        battleMb.Init(Enemies);
    }
}
