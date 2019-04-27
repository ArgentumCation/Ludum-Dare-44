using System.Collections.Generic;
using UnityEngine;

public class BattleMB : MonoBehaviour
{
    private BattleManager _battleManager;
    private RoomMB _roomMb;
    
    public void Init(List<Entity> enemies, RoomMB r)
    {
        _roomMb = r;
        _battleManager = new BattleManager(Player.Team, enemies);
    }
}