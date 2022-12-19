using System;
using UnityEngine;

namespace _Root.Code.Abstractions
{
    public abstract class EnemyBase 
    {
        public event Action<EnemyBase> OnDeath;
        
        public EnemyViewBase View { get; private set; }

        private IEnemyData _enemyData;
        public IEnemyData EnemyData => _enemyData;
        
        protected EnemyBase(IEnemyData enemyData)
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