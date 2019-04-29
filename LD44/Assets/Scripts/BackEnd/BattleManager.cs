using System.Collections.Generic;

public class BattleManager
{
    public static BattleManager BattleManagerRef;

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
            // TODO lose
        }

        if (Enemies.Remove(e))
        {
            if (Enemies.Count == 0)
            {
                RoomMB.ActiveRoom.Exit();
            }

            return;
        }

        Friendlies.Remove(e);
        TeamMB.TeamRef.TeamUpdated();
    }
}
