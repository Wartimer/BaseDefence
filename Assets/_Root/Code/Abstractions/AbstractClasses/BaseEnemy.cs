using System;
using UnityEngine;

namespace _Root.Code.Abstractions
{
    public abstract class BaseEnemy 
    {
        public event Action<BaseEnemy> OnDeath;
        
        public EnemyViewBase View { get; private set; }

        private IEnemyData _enemyData;
        public IEnemyData EnemyData => _enemyData;
        
        protected BaseEnemy(IEnemyData enemyData)
        {
            _enemyData = enemyData ?? throw new NullReferenceException($"{nameof(enemyData)} is not found");
        }
        
        public virtual void Spawn(Vector3 spawnPos)
        {
            View = EnemyData.EnemyView as EnemyViewBase;
            View.transform.position = spawnPos;
        }
        
        private void Death()
        {
            OnDeath?.Invoke(this);
        }
    }
}