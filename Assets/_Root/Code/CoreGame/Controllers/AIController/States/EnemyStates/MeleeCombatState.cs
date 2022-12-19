using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enums;
using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class MeleeCombatState : StateBase
    {
        private float _rotaitionSpeed;
        public MeleeCombatState(IEnemy enemy) : base(enemy)
        {
            _name = EnemyStateType.CombatState;
            _rotaitionSpeed = _enemy.EnemyData.EnemyStatsData.CombatRotSpeed;
        }
        
        public override void Enter()
        {
            Debug.Log("Enter CombatState state");
            _enemy.EnemyAnimator.SetTrigger("isMeleeCombat");
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            var enemyTransform = _enemy.View.transform;
            Vector3 direction = _enemy.Target.Transform.position - enemyTransform.position;
            float angle = Vector3.Angle(direction, enemyTransform.forward);
            direction.y = 0;

            enemyTransform.rotation =
                Quaternion.Slerp(enemyTransform.rotation, 
                    Quaternion.LookRotation(direction), deltaTime * _rotaitionSpeed);

            if (!CanAttackPlayer())
            {
                _nextState = new Idle(_enemy);
                _stage = StateEvent.Exit;
            }
        }

        public override void Exit()
        {
            _enemy.EnemyAnimator.ResetTrigger("isMeleeCombat");
            base.Exit();
        }
    }
}