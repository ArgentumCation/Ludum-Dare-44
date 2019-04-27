using System.Collections.Generic;

public class BattleManager
{
    public List<Entity> Enemies;

    public List<Entity> Friendlies;

    public BattleManager(List<Entity> friendlies, List<Entity> enemies)
    {
        Friendlies = friendlies;
        Enemies = enemies;
    }

}
