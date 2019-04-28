public class TestCard : AttackCard
{
    public TestCard()
    {
        NumTargets = 1;
        AttackDamage = 3;
        HealthCost = 2;
        Description = "Test Card\n2 HP\nDeals 3 damage to a single target.";
    }
}