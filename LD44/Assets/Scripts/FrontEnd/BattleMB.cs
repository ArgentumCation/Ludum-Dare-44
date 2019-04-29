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
    }

    private void Update()
    {
        if (_battleManager == null)
            return;
        
        if (_battleManager.Enemies.Count == 0)
            Destroy(gameObject);
    }

    public void End()
    {
        foreach (Entity e in Player.Team)
            e.Buffs.Clear();
    }
}
