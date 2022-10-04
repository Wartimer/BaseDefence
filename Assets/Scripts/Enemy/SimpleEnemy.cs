using System;
using System.Collections.Generic;
using Data;
using Interfaces;
using Spawner;
using UnitBehavior;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    internal class SimpleEnemy : BaseEnemy, IEnemy
    {
        public NavMeshAgent NavMeshAgent { get; private set; }
        public ITarget Target { get; private set; }
        public ITarget StartTarget { get; private set; }
        
        public Animator EnemyAnimator { get; private set; }
        private int _speedId;
        private int _animIDCombatState;
        private int _animIDAttackType;
        public int SpeedId => _speedId;
        public int AnimIDCombatState => _animIDCombatState;
        public int AnimIDAttackType => _animIDAttackType;
        
        public bool IsAttacking { get; set; }
        public bool IsRecovering { get; set; }
        
        public StateMachine StateMachine { get; private set; }
        public EnemyStateType CurrentState { get; private set; }
        private Dictionary<EnemyStateType, State> _states;
        public Dictionary<EnemyStateType, State> States => _states;

        public SimpleEnemy(IEnemyData enemyData) : base(enemyData)
        {
            CacheAnimIDs();
            _states = new Dictionary<EnemyStateType, State>();
            InitializeStates();
        }
        
        public override void Spawn(Vector3 spawnPosition, ITarget startTarget)
        {
            base.Spawn(spawnPosition, startTarget);
            StartTarget = startTarget;
            Target = StartTarget;
            NavMeshAgent = View.GetComponent<NavMeshAgent>();
            EnemyAnimator = View.GetComponent<Animator>();
            StateMachine = new StateMachine();
            StateMachine.Initialize(_states[EnemyStateType.Idle]);
        }
        
        public void SetTarget(ITarget target)
        {
            Target = target;
            if (Target != null && NavMeshAgent.isActiveAndEnabled)
            {
                NavMeshAgent.destination = Target.Transform.position;
                NavMeshAgent.stoppingDistance = EnemyData.EnemyStatsData.StoppingDistance;
            }
        }
        
        private void InitializeStates()
        {
            _states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
            _states.Add(EnemyStateType.Follow, new EnemyFollowTargetState(this));
            _states.Add(EnemyStateType.AttackBase, new EnemyBaseAttackState(this));
            _states.Add(EnemyStateType.CombatState, new EnemyCombatState(this));
        }

        private void CacheAnimIDs()
        {
            _speedId = Animator.StringToHash("Speed");
            _animIDCombatState = Animator.StringToHash("CombatState");
            _animIDAttackType = Animator.StringToHash("AttackType");
        }
        
    }
}