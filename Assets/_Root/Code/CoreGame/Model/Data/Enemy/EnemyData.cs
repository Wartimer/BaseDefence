using _Root.Code.Abstractions;
using Data;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Utility.ResourceManagement;

namespace _Root.Code.Data
{

    public abstract class EnemyData : ScriptableObject, IEnemyData
    {
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private AssetReference _enemyView;
        [SerializeField] private EnemyStatsData _enemyStatsData;
        [SerializeField] private EnemyAIData _enemyAIData;
        [SerializeField] private AnimationData _enemyAnimData;

        public EnemyType Type => enemyType;
        public IEnemy EnemyView =>
            AddressablesLoader.LoadGameObject(_enemyView).GetComponent<IEnemy>();
        public IEnemyStatsData EnemyStatsData => _enemyStatsData;
        public IEnemyAIData EnemyAIData => _enemyAIData;
        public AnimationData EnemyAnimData => _enemyAnimData;
    }
}