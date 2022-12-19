using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enums;
using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class Follow : StateBase
    {
        public Follow(IEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.Follow;
            
        }
        
        public override void Enter()
        {
            Debug.Log("Enter following state");
//            _enemy.AISeeker;
            _enemy.SetTarget(_enemy.DefaultTarget);
            _enemy.EnemyAnimator.SetTrigger("isWalking");
            base.Enter();
        }

        public override void Update(float deltaTime)
        {

            if (Vector3.Distance(_enemy.View.transform.position, _enemy.Target.Transform.position) <= _enemy.EnemyData.EnemyAIData.MeleeDist)
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

        public override void Exit()
        {
            _enemy.EnemyAnimator.ResetTrigger("isWalking");
            base.Exit();
        }
    }
}