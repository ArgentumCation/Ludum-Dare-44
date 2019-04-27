using System.Collections.Generic;

public class Player : Entity
{
    public static Player PlayerRef;

    public static List<Entity> Team;

    public Artifact[] Artifacts;

    public Player()
    {
        if(PlayerRef != null)
        {
            throw new System.Exception("Tried to make second player");
        }
        PlayerRef = this;
        Team = new List<Entity> { this };
    }

    public bool CanCast(Card c)
    {
        return c.HealthCost < CurrentHealth;
    }

    public void TakeCastDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void TakeHitDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void UseFountain()
    {
        CurrentHealth = MaxHealth;
        Team = new List<Entity> { this };
    }
}
