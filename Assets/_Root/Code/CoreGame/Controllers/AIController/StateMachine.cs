using _Root.Code.Abstractions;

namespace UnitBehavior
{
    internal class StateMachine
    {
        private StateBase _currentState;
        public StateBase CurrentState => _currentState;
        
        public void Initialize(StateBase startState)
        {
            _currentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(StateBase newState)
        {
            CurrentState.Exit();
            SetCurrentState(newState);
            CurrentState.Enter();
        }

        private void SetCurrentState(StateBase state) =>
            _currentState = state;
    }
}