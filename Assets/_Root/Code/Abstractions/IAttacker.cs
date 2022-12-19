namespace _Root.Code.Abstractions
{
    public interface IAttacker
    {
        bool IsAttacking { get; }
        bool IsRecovering { get; }
    }
}