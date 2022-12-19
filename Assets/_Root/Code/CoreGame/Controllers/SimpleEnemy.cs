using _Root.Code.Abstractions;
using UnitBehavior;
using UnityEngine;
using UnityEngine.AI;
using State = _Root.Code.Abstractions;

namespace Enemy
{
    internal class SimpleEnemy : BaseEnemy, IEnemy
    {
        public NavMeshAgent NavMeshAgent { get; private set; }

        public IPlayer Player{
            get;
            private set;
        }
        
        public ITarget Target { get; set; }
        public ITarget DefaultTarget { get; private set; }

        public Animator EnemyAnimator { get; private set; }
        
        public bool IsAttacking { get; set; }
        public bool IsRecovering { get; set; }

        private IState _currentState;
        public IState CurrentState 
        { 
            get=> _currentState;
            set => _currentState = value;
        }

        public SimpleEnemy(IEnemyData enemyData) : base(enemyData)
        { }
        
        public override void Spawn(Vector3 spawnPosition)
        {
            base.Spawn(spawnPosition);
            NavMeshAgent = View.GetComponent<NavMeshAgent>();
            EnemyAnimator = View.GetComponent<Animator>();
            _currentState = new Idle(this);
        }
        
        public void SetTarget(ITarget target)
        {
            Target = target;
            DefaultTarget = Target;
        }

        public void SetPlayer(Player.Player player)
        {
            Player = player;
        }
    }
}