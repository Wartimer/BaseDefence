using System;
using UnityEngine;

namespace AnimatorStates
{
    internal sealed class LeftPunchState : StateMachineBehaviour
    {
        public event Action EnterState;
        public event Action ExitState;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            EnterState?.Invoke();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            ExitState?.Invoke();
        }
    }
}