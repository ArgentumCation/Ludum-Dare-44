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
        
        TeamUpdated();
    }

    public void TeamUpdated()
    {
        foreach (EntityMB e in TeamEntities)
        {
            Destroy(e.gameObject);
        }
        TeamEntities.Clear();
        for (int i = 0; i < Player.Team.Count; i++)
        {
            GameObject newMember = Instantiate(EntityMB.EntityPrefab);
            //newMember.transform.position = new Vector3(0.9f + i * 1.7f, 6, 0);
            newMember.transform.position = new Vector3(3.5f, 6, 0);
            EntityMB newEntityMb = newMember.GetComponent<EntityMB>();
            newEntityMb.Init(Player.Team[i]);
            TeamEntities.Add(newEntityMb);
        }
    }
}
