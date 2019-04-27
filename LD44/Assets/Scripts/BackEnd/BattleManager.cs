using System;

public class BattleManager
{
    public List<Entity> enemies;

    public List<Entity> friendlies;

    public BattleManager(List<Entity> friendlies, List<Entity> enemies)
    {
        this.friendlies = friendlies;
        this.enemies = enemies;
    }

}
