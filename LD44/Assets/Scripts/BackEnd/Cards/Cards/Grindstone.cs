public class Grindstone : BuffCard
{
    public Grindstone()
    {
        Description = "Grindstone\n3 HP\nIncrease a single target's attack by 25%.";
        MyBuff = new Buff(BuffType.AttackBuff, 25);
        NumTargets = 1;
    }

}
