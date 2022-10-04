using System;
using System.Collections.Generic;
using Data;
using Enemy;
using Interfaces;
using Map;
using Spawner;
using UnityEngine;
using Pools;
using Random = UnityEngine.Random;

namespace Pools
{
    internal class EnemyPool : PoolBase<EnemyView>
    {
        public event Action<SimpleEnemy> EnemyCreated;
        
        private EnemyFactory _enemyFactory;
        private List<ITarget> _startTargets;

        internal EnemyPool(int poolCapacity, Transform root, EnemyFactory enemyFactory) 
            : base(poolCapacity, root)
        {
            _enemyFactory = enemyFactory;
            _startTargets = new List<ITarget>();
        }

        public override EnemyView GetObject()
        {
            EnemyView view;

            if (ObjectPool.Count == 0)
            {
                for (var i = 0; i <= PoolCapacity; i++)
                {
                    var enemy = _enemyFactory.GetEnemy(EnemyType.Melee);
                    enemy.Spawn(Root.position, null);
                    view = enemy.View;
                    ReturnToPool(view);
                    EnemyCreated?.Invoke(enemy as SimpleEnemy);
                }
            }

            view = ObjectPool.Pop();
            view.gameObject.SetActive(true);
            view.transform.SetParent(null);
            return view;
        }
        
        public override void ReturnToPool(EnemyView obj)
        {
            var transform = obj.transform;
            transform.SetParent(Root);
            transform.localPosition = Vector3.zero;
            ObjectPool.Push(obj);
            obj.gameObject.SetActive(false);
        }

        public void SettleThePool()
        {
            for (var i = 0; i <= PoolCapacity; i++)
            {
                EnemyView view;
                var enemy = _enemyFactory.GetEnemy(EnemyType.Melee);
                enemy.Spawn(Root.position, null);
                view = enemy.View;
                ReturnToPool(view);
                EnemyCreated?.Invoke(enemy as SimpleEnemy);
            }
        }
    }
}