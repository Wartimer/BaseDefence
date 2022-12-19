using _Root.Code.Abstractions.Enums;
using UnityEngine;


namespace _Root.Code.Abstractions
{
    public abstract class StateBase : IState
    {
        protected StateEvent _stage;
        protected EnemyStateType _name;
        protected IEnemy _enemy;
        protected StateBase _nextState;

        public StateBase(IEnemy enemy)
        {
            _enemy = enemy;
            _stage = StateEvent.Enter;
        }

        public virtual void Enter()
        {
            _stage = StateEvent.Update;
            
        }
        public virtual void Update(float deltaTime)
        {
            _stage = StateEvent.Update;
        }
        public virtual void Exit()
        {
            _stage = StateEvent.Exit;
        }

        public IState Process(float deltaTime)
        {
            if(_stage == StateEvent.Enter) Enter();
            if(_stage == StateEvent.Update) Update(deltaTime);
            if(_stage == StateEvent.Exit)
            {
                Exit();
                return _nextState;
            }

            return this;
        }

        public bool CanSeePlayer()
        {

            var enemyTransform = _enemy.View.transform;
            Vector3 direction = _enemy.Player.View.transform.position - enemyTransform.position;
            var angle = Vector3.Angle(direction, enemyTransform.forward);

            if (direction.magnitude < _enemy.EnemyData.EnemyAIData.VisDistance &&
                angle < _enemy.EnemyData.EnemyAIData.VisAngle)
            {
                return true;
            }
        
            return false;
        }

        public bool CanAttackPlayer()
        {
            var enemyTransform = _enemy.View.transform;
            Vector3 direction = _enemy.Player.View.transform.position - enemyTransform.position;
            if (direction.magnitude > _enemy.EnemyData.EnemyAIData.MeleeDist) return false;
            return true;
        }

    }
}