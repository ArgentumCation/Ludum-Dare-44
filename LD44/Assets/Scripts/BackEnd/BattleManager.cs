using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager
{
    public static BattleManager BattleManagerRef;
    public static EndGameMB EndGameObject;

    public List<Entity> Enemies;

    public List<Entity> Friendlies;

    public BattleManager(List<Entity> friendlies, List<Entity> enemies)
    {
        BattleManagerRef = this;

        Friendlies = friendlies;
        Enemies = enemies;
        BattleActionManager.State = BattleActionState.SelectCard;
    }

    public void Die(Entity e)
    {
        if (e == Player.PlayerRef)
        {
            EndGameObject.gameObject.SetActive(true);
            EndGameObject.Activate(false);
        }

        if (Enemies.Remove(e))
        {
            if (Enemies.Count == 0)
            {
                RoomMB.ActiveRoom.StartCoroutine(WaitExitRoom());
            }

            return;
        }

        Friendlies.Remove(e);
        TeamMB.TeamRef.TeamUpdated();
    }

    private IEnumerator WaitExitRoom()
    {
        yield return new WaitForSeconds(2);
        RoomMB.ActiveRoom.Exit();
    }
}
