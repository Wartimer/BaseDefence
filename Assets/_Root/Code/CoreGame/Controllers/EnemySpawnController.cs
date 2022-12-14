using System;
using System.Collections.Generic;
using _Root.Code.Abstractions;
using _Root.Code.Abstractions.Enemy;
using Enemy;
using Map;
using Pools;
using Spawner;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Controller
{
    internal sealed class EnemySpawnController : IExecute, IDisposable
    {
        private Player.Player _player;
        private EnemyPool _enemyPool;
        private SpawnerView[] _spawnPoses;
        private List<IEnemy> _spawnedEnemies;
        
        private int _enemiesLimitOnMap = 15;
        private float _firstSpawnTime = 0;
        private float _nextSpawnTime = 4f;
        
        public List<IEnemy> SpawnedEnemies => _spawnedEnemies;
        public EnemyPool EnemyPool => _enemyPool;

        internal EnemySpawnController(EnemyFactory enemyFactory, Player.Player player, MapView mapView)
        {
            _spawnedEnemies = new List<IEnemy>();
            
            var root = new GameObject("EnemyRoot");
            root.transform.position = new Vector3(0, 5f, 0);
            
            _spawnPoses = new SpawnerView[mapView.Spawners.Count];
            mapView.Spawners.CopyTo(_spawnPoses);
            
            _enemyPool = new EnemyPool(1, root.transform, enemyFactory, mapView.AttackPoints);
            _player = player;
            _enemyPool.EnemyCreated += OnPoolEnemyCreated;
        }

        public void Execute()
        {
            _firstSpawnTime += Time.deltaTime;
            if (_firstSpawnTime >= _nextSpawnTime)
                SpawnObject();
        }

        private void SpawnObject()
        { 
            var enemy = _enemyPool.GetObject();
            SetObjectPosition(enemy.View);
            enemy.SetPlayer(_player);
            _firstSpawnTime = 0;
        }

        private void OnPoolEnemyCreated(SimpleEnemy enemy) =>
            _spawnedEnemies.Add(enemy);

        private void SetObjectPosition(EnemyView enemyView)
        {
            var enemyTransform = enemyView.transform;
            var rnd = Random.Range(0, _spawnPoses.Length);
            var colliders = new Collider[1];
            var inPlace = false;

            do
            {
                var rect = _spawnPoses[rnd].RectTransform.rect;
                var position = _spawnPoses[rnd].transform.position;
                var spawnPos = new Vector3(
                    Random.Range(position.x - rect.width / 2, position.x + rect.width / 2),
                    position.y,
                    Random.Range(position.z - rect.height / 2, position.z + rect.height / 2));

                var radiusForCheck = enemyView.Collider.radius;
                var isEmpty = Physics.OverlapSphereNonAlloc(spawnPos, radiusForCheck, colliders) == 0;

                if (!isEmpty) continue;

                enemyTransform.position = spawnPos;
                var spawnRotation = _spawnPoses[rnd].transform.rotation;
                enemyTransform.rotation = spawnRotation;
                inPlace = !inPlace;

            } while (inPlace);
            
        }
        
        public void Dispose()
        {
            _enemyPool.EnemyCreated -= OnPoolEnemyCreated;
        }
    }
}