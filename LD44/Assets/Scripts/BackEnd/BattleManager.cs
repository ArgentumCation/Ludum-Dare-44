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
        
        Deck.DrawCard();
        Deck.DrawCard();
        Deck.DrawCard();
    }

    public void Die(Entity e)
    {
        if (e == Player.PlayerRef)
        {
            // TODO end game
        }
        
        if (Enemies.Remove(e))
        {
            if (Enemies.Count == 0)
            {
                // TODO next room
            }

            return;
        }
        
        Friendlies.Remove(e);
    }
}
