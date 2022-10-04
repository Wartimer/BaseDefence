using System.Collections.Generic;
using UnitBehavior;

namespace Interfaces
{
    internal interface IHaveStates
    {
        StateMachine StateMachine { get; }
        EnemyStateType CurrentState { get; }
        
        Dictionary<EnemyStateType, State> States { get; }
    }
}