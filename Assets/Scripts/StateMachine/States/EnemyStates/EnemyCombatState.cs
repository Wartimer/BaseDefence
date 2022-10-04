using System;
using AnimatorStates;
using Data;
using Enemy;
using Enemy.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnitBehavior
{
    internal sealed class EnemyCombatState : State, IDisposable
    {
        private SimpleEnemy _enemy;
        private EnemyView _enemyView;
        private Vector3 _currentPosition;
        private float _firstSwitch = 0;
        private float _attackTimeOffset = 1.5f;
        private float _recoveryTime = 1.5f;
        private readonly int _idCombatState;
        private readonly int _idPunchLeft;
        private readonly int _idPunchRight;
        private LeftPunchState _leftPunchState;
        private RightPunchState _rightPunchState;
        private int _counter = 1;

        public EnemyCombatState(SimpleEnemy enemy)
        {
            _enemy = enemy;
            _idCombatState = Animator.StringToHash("CombatState");
            _idPunchLeft = Animator.StringToHash("PunchLeft");
            _idPunchRight = Animator.StringToHash("PunchRight");
        }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Combat State");
            _leftPunchState = _enemy.EnemyAnimator.GetBehaviour<LeftPunchState>();
            _rightPunchState = _enemy.EnemyAnimator.GetBehaviour<RightPunchState>();
            _leftPunchState.ExitState += StartRecovery;
            _rightPunchState.ExitState += StartRecovery;
            
            _enemy.EnemyAnimator.SetBool(_idCombatState, true);

            
            if (_enemy is IEnemyViewProvider viewProvider)
            {
                _enemyView = viewProvider.View;
                _currentPosition = _enemyView.transform.position;
            }
        }

        private void StartRecovery()
        {
            _firstSwitch = 0;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            StayInPlace();
            RotateTowardsTarget();
            _firstSwitch += deltaTime;
            var stateInfo = _enemy.EnemyAnimator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsTag("PunchLeft") || stateInfo.IsTag("PunchRight"))
            {
                _enemy.IsAttacking = true;
                return;
            }
            if(_firstSwitch >= _attackTimeOffset)
                PunchTarget();
        }

        private void PunchTarget()
        {
            GetBaseAttackClip();
        }

        private void RotateTowardsTarget()
        {
            var targetDirection = _enemy.Target.Transform.position - _enemyView.transform.position;
            targetDirection.y = 0;
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
           _enemyView.transform.rotation = Quaternion.Slerp(_enemyView.transform.rotation, rotation, 0.5f);
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.EnemyAnimator.SetBool(_idCombatState, false);
            _enemy.IsAttacking = false;
        }
        
        private void StayInPlace()=>
            _enemyView.transform.position = _currentPosition;
        
        private void GetBaseAttackClip()
        {
            var rnd = Random.Range(1, 3);
            var stateId = rnd switch
            {
                1 => _idPunchLeft,
                2 => _idPunchRight,
                _ => _idPunchRight
            };
            
            _enemy.EnemyAnimator.SetTrigger(stateId);
        }
        
        private bool IsInAttack()
        {
            var stateInfo = _enemy.EnemyAnimator.GetCurrentAnimatorStateInfo(0);
            return _enemy.IsAttacking = (stateInfo.IsName("PunchLeft") 
                                         || stateInfo.IsName("PunchRight"));
        }


        public void Dispose()
        {
            _leftPunchState.ExitState -= StartRecovery;
            _rightPunchState.ExitState -= StartRecovery;            
        }
    }
}