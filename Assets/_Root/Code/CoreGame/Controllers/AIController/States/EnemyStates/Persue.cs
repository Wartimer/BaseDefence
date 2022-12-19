using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal class Pursue : State
    {
        public Pursue(SimpleEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.Pursue;
            _enemy.NavMeshAgent.speed = _enemy.EnemyData.EnemyStatsData.RunSpeed;
        }
        
        public override void Enter()
        {
            Debug.Log("Enter Pursue state");
            _enemy.Target = _enemy.Player;
            _enemy.EnemyAnimator.SetTrigger("isRunning");
            _enemy.NavMeshAgent.enabled = true;
            _enemy.NavMeshAgent.destination = _enemy.Target.Transform.position;

            //_enemy.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            if (_enemy.NavMeshAgent.hasPath)
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
        }

        public override void Exit()
        {
            _enemy.EnemyAnimator.ResetTrigger("isRunning");
            base.Exit();
        }
    }
}