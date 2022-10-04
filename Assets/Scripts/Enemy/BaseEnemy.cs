using System;
using Data;
using Enemy.Interfaces;
using Interfaces;
using UnityEngine;


namespace Enemy
{
    internal abstract class BaseEnemy : IEnemyViewProvider
    {
        public event Action<BaseEnemy> OnDeath;
        
        public EnemyView View { get; private set; }

        private IEnemyData _enemyData;
        public IEnemyData EnemyData => _enemyData;
        
        protected BaseEnemy(IEnemyData enemyData)
        {
            _enemyData = enemyData ?? throw new NullReferenceException($"{nameof(enemyData)} is not found");
        }
        
        public virtual void Spawn(Vector3 spawnPos, ITarget startTarget)
        {
            View = EnemyData.EnemyView;
            View.transform.position = spawnPos;
           
        }
        
        private void Death()
        {
            OnDeath?.Invoke(this);
        }
    }
}