using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enums;
using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal class Pursue : StateBase
    {
        public Pursue(IEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.Pursue;
        }
        
        public override void Enter()
        {
            Debug.Log("Enter Pursue state");
            _enemy.SetTarget(_enemy.Player as ITarget);
            _enemy.EnemyAnimator.SetTrigger("isRunning");

            //_enemy.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            if (CanAttackPlayer())
            {
                _nextState = new MeleeCombatState(_enemy);
                _stage = StateEvent.Exit;
            }
            else if (!CanSeePlayer())
            {
                _nextState = new Idle(_enemy);
                _stage = StateEvent.Exit;
            }
        }

        public override void Exit()
        {
            _enemy.EnemyAnimator.ResetTrigger("isRunning");
            base.Exit();
        }
    }
}