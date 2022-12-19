namespace _Root.Code.Abstractions
{
    public interface ILateExecute : IController
    {
        void LateExecute();
    }
}