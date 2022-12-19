using System;
using _Root.Code.Abstractions.Enums;
using UnityEngine;

namespace Spawner
{
    [Serializable]
    public class Spawn
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private int count;

        public EnemyType Type => type;
        public int Count => count;
    }
    
    [RequireComponent(typeof(RectTransform))]
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField] private Spawn[] spawns;
        
        public Spawn[] Spawns => spawns;
        public RectTransform RectTransform => GetComponent<RectTransform>();
    }
}