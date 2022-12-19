namespace _Root.Code.Abstractions
{
    public interface IState
    {
        public void Enter();
        public void Update(float deltaTime);
        public void Exit();

        public IState Process(float deltaTime);
    }
}