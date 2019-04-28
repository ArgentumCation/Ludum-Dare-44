public struct Buff
{
    public readonly BuffType Type;
    public readonly float Amount;

    public Buff(BuffType t, float amount)
    {
        Type = t;
        Amount = amount;
    }
}
