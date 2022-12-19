namespace _Root.Code.Abstractions
{
    public interface IHaveTarget 
    {
        ITarget Target { get; }
        ITarget DefaultTarget { get; }
        void SetTarget(ITarget target);
    }
}