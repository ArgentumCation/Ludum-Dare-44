using System.Collections.Generic;
using UnityEngine;

public class BattleMB : MonoBehaviour
{
    private BattleManager _battleManager;

    private void Start()
    {
        name = "Battle";
    }

    public void Init(List<Entity> enemies)
    {
        _battleManager = new BattleManager(Player.Team, enemies);
        
        // TODO apply artifact buffs
    }

    private void Update()
    {
        if (_battleManager == null)
            return;
        
        
    }

    public void End()
    {
        foreach (Entity e in Player.Team)
        {
            e.Buffs.Clear();
        }
    }
}