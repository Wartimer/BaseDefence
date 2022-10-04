using Data;
using Enemy;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class EnemyFollowTargetState : State
    {
        private SimpleEnemy _enemy;
        private float _animationBlend;
        private float _speed;
        
        public EnemyFollowTargetState(SimpleEnemy enemy)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("In enemy Follow target state");
            _enemy.NavMeshAgent.isStopped = false;
            _enemy.NavMeshAgent.destination = _enemy.Target.Transform.position;
            
            SetNavAgentSpeed();

        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            //_enemy.EnemyAnimator.SetFloat(_enemy.SpeedId, _enemy.NavMeshAgent.velocity.magnitude);
            Move(_enemy);
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.NavMeshAgent.speed = 0;
            _enemy.NavMeshAgent.isStopped = true;

        }

        private void SetNavAgentSpeed()
        {
            var speed = _enemy.Target.Priority switch
            {
                1 => _enemy.EnemyData.EnemyStatsData.WalkSpeed,
                1000 => _enemy.EnemyData.EnemyStatsData.RunSpeed,
                _ => _enemy.EnemyData.EnemyStatsData.WalkSpeed
            };
            
            _enemy.NavMeshAgent.speed = speed;
        }
        
        private void Move(IEnemy enemy)
        {
            float targetSpeed = enemy.NavMeshAgent.speed;
            
            if (enemy.NavMeshAgent.velocity == Vector3.zero) targetSpeed = 0.0f;

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * _enemy.NavMeshAgent.acceleration);
            if (_animationBlend < 0.01f) _animationBlend = 0f;

            _enemy.EnemyAnimator.SetFloat(_enemy.SpeedId, _animationBlend);
        }
    }
}