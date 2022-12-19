using System.Collections.Generic;
using _Root.Code.Abstractions.Enemy;
using _Root.Code.Abstractions.Enums;
using Data;
using Enemy;

namespace Spawner
{
    internal class EnemyFactory
    {
        private Dictionary<EnemyType, EnemyData> _dataDictionary;

        public EnemyFactory(EnemyDataList enemyDataList)
        {
            _dataDictionary = enemyDataList.EnemyDataDictionary;
        }

        public BaseEnemy GetEnemy(EnemyType enemyType)
        {
            return new SimpleEnemy(_dataDictionary[enemyType]);
        }
    }
}