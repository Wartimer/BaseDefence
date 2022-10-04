using System;
using System.Collections.Generic;
using Data;
using Enemy.Interfaces;
using Interfaces;
using Player;
using Pools;
using Spawner;
using UnitBehavior;
using UnityEngine;

namespace Runtime.Controller
{
    internal sealed class EnemiesController : IExecute, IDisposable, IInGameObserver<ITarget>
    {
        private List<IEnemy> _enemies;
        private EnemyPool _enemyPool;
        private float _destinationReachedThreshold = 0.6f;
        
        public EnemiesController(EnemySpawnController spawnController)
        {
            _enemies = new List<IEnemy>();

            for (int i = 0; i < spawnController.SpawnedEnemies.Count; i++)
            {
                _enemies.Add(spawnController.SpawnedEnemies[i]);
            }
            
            _enemyPool = spawnController.EnemyPool;
            _enemyPool.EnemyCreated += AddEnemy;
        }
        
        public void Execute()
        {
            if (_enemies.Count == 0) return;
            for (var i = 0; i < _enemies.Count; i++)
            {
                if(_enemies[i] is IEnemyViewProvider enemyView)
                    if (!enemyView.View.gameObject.activeSelf) continue;
                
                if (_enemies[i].Target == null)
                {
                    if (_enemies[i].StateMachine.CurrentState != _enemies[i].States[EnemyStateType.Idle])
                    {
                        _enemies[i].StateMachine.ChangeState(_enemies[i].States[EnemyStateType.Idle]);
                    }
                    continue;
                }
                
                if(_enemies[i].Target != null)
                {
                    if (TargetReached(_enemies[i]))
                    {
                        if(_enemies[i].StateMachine.CurrentState == _enemies[i].States[EnemyStateType.CombatState])
                            continue;
                        _enemies[i].StateMachine.ChangeState(_enemies[i].States[EnemyStateType.CombatState]);
                    }
                    if (!TargetReached(_enemies[i]))
                    {
                        if (_enemies[i].StateMachine.CurrentState == _enemies[i].States[EnemyStateType.Follow])
                            continue;
                        _enemies[i].StateMachine.ChangeState(_enemies[i].States[EnemyStateType.Follow]);
                    }
                }

                if (TargetAway(_enemies[i]) && _enemies[i].Target != null)
                {
                    _enemies[i].SetTarget(null);
                    return;
                }
            }
            
            UpdateStates();
        }
        
        private bool TargetReached(IHaveAI agent)
        {
            var navAgent = agent.NavMeshAgent;
            var distance = Vector3.Distance(navAgent.transform.position, navAgent.destination);
            return  distance <= navAgent.stoppingDistance;
        }
        
        

        private bool TargetAway(IHaveAI agent)
        {
            var distanceToTarget = Vector3.Distance(agent.NavMeshAgent.transform.position, agent.NavMeshAgent.destination);
            return distanceToTarget >= 3;
        }

        private void UpdateStates()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].StateMachine.CurrentState.Update(Time.deltaTime);
            }
        }

        private void AddEnemy(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Dispose()
        {
            _enemyPool.EnemyCreated -= AddEnemy;
        }

        public void ObserverUpdate(ITarget target)
        {
            for (int i = 0; i < _enemies.Count; i++)
                _enemies[i].SetTarget(target);
        }
    } 
}
