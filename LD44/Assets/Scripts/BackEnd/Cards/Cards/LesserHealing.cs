public class LesserHealing : HealingCard
{
	public LesserHealing()
	{
        NumTargets = 1;
        AttackDamage = -2;
        HealthCost = 0;
        Description = "Small Blood Transfusion\n0 HP\nHeal 2 HP to a single friendly target";

    }

}
