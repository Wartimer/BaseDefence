using Interfaces;

namespace Enemy.Interfaces
{
    internal interface IHaveTarget 
    {
        ITarget Target { get; }
        void SetTarget(ITarget target);
    }
}