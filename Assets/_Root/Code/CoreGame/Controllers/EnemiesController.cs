using System;
using System.Collections.Generic;
using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enemy;
using Data;
using Map;
using Pools;
using UnityEngine;

namespace Runtime.Controller
{
    internal sealed class EnemiesController : IExecute, IDisposable, IInGameObserver<ITarget>
    {
        private List<IEnemy> _enemies;
        private EnemyPool _enemyPool;
        private List<Point> _targets;
        
        public EnemiesController(EnemySpawnController spawnController, List<Point> targets)
        {
            _enemies = spawnController.SpawnedEnemies;
            
            _targets = targets;
        }
        
        public void Execute()
        {
            ProcessStates();
        }
        
        private void ProcessStates()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if(_enemies[i].NavMeshAgent.isActiveAndEnabled)
                    _enemies[i].CurrentState = _enemies[i].CurrentState.Process(Time.deltaTime);
            }
        }

        private void AddEnemy(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void ObserverUpdate(ITarget target)
        {
            for (int i = 0; i < _enemies.Count; i++)
                _enemies[i].SetTarget(target);
        }
        
        public void Dispose()
        {
            _enemyPool.EnemyCreated -= AddEnemy;
        }
    } 
}
