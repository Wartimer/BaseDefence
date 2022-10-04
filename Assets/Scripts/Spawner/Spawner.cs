using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class Spawner
    {
        private readonly GameObject _spawnerView;
        private readonly float _spawnRadius;
        private readonly GameObject _enemyPrefab;
        private readonly int _enemyNumber;
        private readonly Dictionary<int, GameObject> _enemiesObjects;
        private readonly GameObject _root;
    }
}