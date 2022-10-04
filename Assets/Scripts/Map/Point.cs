using System.Collections.Generic;
using Enemy;
using Interfaces;
using UnityEngine;

namespace Map
{
    internal sealed class Point : MonoBehaviour, ITarget
    {
        [SerializeField] private List<EnemyView> _attackers;
        [SerializeField] private int _priority;
        public int Priority { get; }
        public Transform Transform => transform;
    }
}