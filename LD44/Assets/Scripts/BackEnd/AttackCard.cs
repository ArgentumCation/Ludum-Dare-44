using System.Collections.Generic;
using System.Linq;

public class AttackCard : Card
{
    // Casts the card effect on all targets
    public void Cast(IEnumerable<Entity> targets)
    {
        List<Entity> targetList = targets.ToList();
        
        if(targetList.Count == NumTargets)
        {
            foreach(Entity target in targetList)
            {
                target.Damage(damageValue());
            }
        }
    }
    
    // returns card attack damage
    protected virtual int damageValue()
    {
        return 0;
    }
}
