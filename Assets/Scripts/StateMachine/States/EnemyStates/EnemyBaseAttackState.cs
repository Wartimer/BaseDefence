using Enemy;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace UnitBehavior
{
    internal sealed class EnemyBaseAttackState : State
    {
        private SimpleEnemy _enemy;

        public EnemyBaseAttackState(SimpleEnemy enemy)
        {
            _enemy = enemy;

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            
        }

        public override void Exit()
        {
            base.Exit();
            
        }
        

    }
}