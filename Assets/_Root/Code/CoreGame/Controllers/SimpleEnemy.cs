using _Root.Code.Abstractions;
using Pathfinding;
using UnitBehavior;
using UnityEngine;
using UnityEngine.AI;
using State = _Root.Code.Abstractions;

namespace Enemy
{
    internal class SimpleEnemy : EnemyBase, IEnemy
    {
        
        public IPlayer Player{
            get;
            private set;
        }
        
        public Seeker AISeeker { get; private set; }
        public ITarget Target { get; set; }
        public ITarget DefaultTarget { get; private set; }

        public Animator EnemyAnimator { get; private set; }
        
        private IState _currentState;
        private StateBase _currentState1;

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
            AISeeker = View.GetComponent<Seeker>();
            EnemyAnimator = View.GetComponent<Animator>();
            _currentState = new Idle(this);
        }
        
        public void SetTarget(ITarget target)
        {
            Target = target;
            DefaultTarget = Target;
        }

        public void SetPlayer(IPlayer player)
        {
            Player = player;
        }


        StateBase IHaveStates.CurrentState
        {
            get => _currentState1;
            set => _currentState1 = value;
        }
    }
}