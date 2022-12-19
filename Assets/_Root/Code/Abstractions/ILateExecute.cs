namespace _Root.Code.Abstractions
{
    internal interface ILateExecute : IController
    {
        void LateExecute();
    }
}