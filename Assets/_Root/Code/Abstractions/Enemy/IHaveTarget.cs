namespace _Root.Code.Abstractions
{
    public interface IHaveTarget 
    {
        ITarget Target { get; }
        void SetTarget(ITarget target);
    }
}