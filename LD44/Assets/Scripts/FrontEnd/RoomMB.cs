using System;
using UnityEngine;

public class RoomMB : MonoBehaviour
{
    private Room _meRoom;
    private RoomType _meType;

    public void Init(Room r, RoomType t)
    {
        _meRoom = r;
        _meType = t;
    }

    public void Init(Room r)
    {
        _meRoom = r;
        
        if (r.GetType() == typeof(BattleRoom))
            _meType = RoomType.BattleRoom;
        else if (r.GetType() == typeof(ArtifactRoom))
            _meType = RoomType.ArtifactRoom;
        else if (r.GetType() == typeof(FountainRoom))
            _meType = RoomType.FountainRoom;
        else
            throw new ArgumentException("Unknown Room: " + r.GetType().FullName);
    }
    
    public void ScrollIn()
    {
        
    }

    public void ScrollOut()
    {
        
    }

    public void Entry()
    {
        _meRoom.Enter();
    }
}