using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamMB : MonoBehaviour
{
    public static TeamMB TeamRef;
    private List<EntityMB> TeamEntities = new List<EntityMB>();

    private void Start()
    {
        if (TeamRef != null)
            throw new Exception("Second team made");
        TeamRef = this;
    }

    public void TeamUpdated()
    {
        TeamEntities.Clear();
        for (int i = 0; i < TeamEntities.Count; i++)
        {
            GameObject newMember = Instantiate(EntityMB.EntityPrefab);
            EntityMB newEntityMb = newMember.GetComponent<EntityMB>();
            newEntityMb.Init(BattleManager.BattleManagerRef.Friendlies[i]);
        }
    }
}
