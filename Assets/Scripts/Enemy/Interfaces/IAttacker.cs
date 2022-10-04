namespace Enemy.Interfaces
{
    internal interface IAttacker
    {
        bool IsAttacking { get; }
        bool IsRecovering { get; }
    }
}