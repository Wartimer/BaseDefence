using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enums;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class Idle : StateBase
    {
        public Idle(IEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.Idle;
        }

        public override void Enter()
        {
            _enemy.EnemyAnimator.SetTrigger("isIdle");
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            if (!_enemy.View.isActiveAndEnabled) return;
           
            if (CanSeePlayer())
            {
                _nextState = new Pursue(_enemy);
                _stage = StateEvent.Exit;
            }
            else if (Vector3.Distance(_enemy.Target.Transform.position, _enemy.View.transform.position) > _enemy.EnemyData.EnemyAIData.MeleeDist)
            {
                _nextState = new Follow(_enemy);
                _stage = StateEvent.Exit;
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Idle state");
            _enemy.EnemyAnimator.ResetTrigger("isIdle");
            base.Exit();
        }
    }
}