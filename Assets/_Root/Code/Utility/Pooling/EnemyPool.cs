using System;
using System.Collections.Generic;
using Spawner;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace _Root.Code.Utility
{
    internal class EnemyPool : PoolBase<SimpleEnemy>
    {
        public delegate void OpDelegate();
        public event Action<SimpleEnemy> EnemyCreated;
        
        private EnemyFactory _enemyFactory;
        private List<AttackPoint> _targets;
        private OpDelegate _fillThePool;
        internal EnemyPool(int poolCapacity, Transform root, EnemyFactory enemyFactory, List<AttackPoint> targets) 
            : base(poolCapacity, root)
        {
            _enemyFactory = enemyFactory;
            _targets = targets;
            _fillThePool += SettleThePool;
        }

        public override SimpleEnemy GetObject()
        {
            if (ObjectPool<>.Count == 0)
            {
                _fillThePool?.Invoke();
            }

            var enemy = ObjectPool.Pop();
            enemy.View.gameObject.SetActive(true);
            enemy.View.transform.SetParent(null);
            return enemy;
        }
        
        public override void ReturnToPool(SimpleEnemy obj)
        {
            var transform = obj.View.transform;
            transform.SetParent(Root);
            transform.localPosition = Vector3.zero;
            ObjectPool.Push(obj);
            obj.View.gameObject.SetActive(false);
        }

        public void SettleThePool()
        {
            for (var i = 0; i <= PoolCapacity; i++)
            {
                if (_enemyFactory.GetEnemy(EnemyType.Melee) is SimpleEnemy enemy)
                {
                    enemy.Spawn(Root.position);
                    enemy.SetTarget(_targets[Random.Range(0,_targets.Count)]);
                    EnemyCreated?.Invoke(enemy);
                    ReturnToPool(enemy);
                }
            }
        }
    }
}