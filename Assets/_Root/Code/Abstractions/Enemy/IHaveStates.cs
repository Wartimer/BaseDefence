namespace _Root.Code.Abstractions
{
    public interface IHaveStates
    {
        StateBase CurrentState { get; set; }
    }
}