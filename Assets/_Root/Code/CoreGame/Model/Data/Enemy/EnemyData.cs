using System.Collections.Generic;
using System.Linq;
using _Root.Code.Abstractions;
using Data.Abilities;
using Enemy;
using Siva.Tool.ResourceManagement;
using Spawner;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{

    public abstract class EnemyData : ScriptableObject, IEnemyData
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private AssetReference _enemyView;
        [SerializeField] private EnemyStatsData _enemyStatsData;
        [SerializeField] private EnemyAIData _enemyAIData;
        [SerializeField] private AnimationData _enemyAnimData;

        public EnemyType Type => enemyType;
        public EnemyView EnemyView =>
            AddressablesLoader.LoadGameObject(_enemyView).GetComponent<EnemyView>();
        public EnemyStatsData EnemyStatsData => _enemyStatsData;
        public EnemyAIData EnemyAIData => _enemyAIData;
        public AnimationData EnemyAnimData => _enemyAnimData;
    }
}