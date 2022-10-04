namespace Runtime.Controller
{
    internal interface ILateExecute : IController
    {
        void LateExecute();
    }
}