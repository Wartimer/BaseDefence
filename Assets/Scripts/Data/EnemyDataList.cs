using System.Collections.Generic;
using System.Linq;
using Spawner;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyDataList", menuName = "Data/EnemyDataList")]
    public class EnemyDataList : ScriptableObject
    {
        [SerializeField] private List<EnemyData> enemyDatas;

        public Dictionary<EnemyType, EnemyData> EnemyDataDictionary => enemyDatas.ToDictionary(enemy => enemy.Type);
    }
}