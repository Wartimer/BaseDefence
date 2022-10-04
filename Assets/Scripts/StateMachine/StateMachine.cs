
namespace UnitBehavior
{
    internal class StateMachine
    {
        private State _currentState;
        public State CurrentState => _currentState;
        
        public void Initialize(State startState)
        {
            _currentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            SetCurrentState(newState);
            CurrentState.Enter();
        }

        private void SetCurrentState(State state) =>
            _currentState = state;
    }
}