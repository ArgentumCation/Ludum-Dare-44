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
        
        switch (r.GetType())
        {
            case typeof(BattleRoom):
                _meType = RoomType.BattleRoom;
                break;
            case typeof(ArtifactRoom):
                _meType = RoomType.ArtifactRoom;
                break;
            case typeof(FountainRoom):
                _meType = RoomType.FountainRoom;
                break;
            default:
                throw new ArgumentException("Unknown Room: " + r.GetType().FullName);
        }
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