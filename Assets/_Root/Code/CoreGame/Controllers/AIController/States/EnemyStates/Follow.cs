using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class Follow : State
    {
        public Follow(SimpleEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.Follow;
            
        }
        
        public override void Enter()
        {
            Debug.Log("Enter following state");
            _enemy.NavMeshAgent.isStopped = false;
            Debug.Log("Path status" + _enemy.NavMeshAgent.pathStatus);
            _enemy.NavMeshAgent.speed = _enemy.EnemyData.EnemyStatsData.WalkSpeed;
            _enemy.NavMeshAgent.destination = _enemy.DefaultTarget.Transform.position;
            _enemy.EnemyAnimator.SetTrigger("isWalking");
            //_enemy.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            if (_enemy.NavMeshAgent.hasPath)
            {
                if (Vector3.Distance(_enemy.View.transform.position, _enemy.Target.Transform.position) <= _enemy.EnemyData.EnemyStatsData.MeleeDist)
                {
                    _nextState = new MeleeCombatState(_enemy);
                    _stage = StateEvent.Exit;
                }
                
                if (CanSeePlayer())
                {
                    _nextState = new Pursue(_enemy);
                    _stage = StateEvent.Exit;
                }
            }
        }

        public override void Exit()
        {
            _enemy.EnemyAnimator.ResetTrigger("isWalking");
            base.Exit();
        }
    }
}