using _Root.Code.Abstractions;
using UnityEngine;

namespace Map
{
    internal sealed class AttackPoint : MonoBehaviour, ITarget
    {
        [SerializeField] private int _priority;
        public int Priority { get; }
        public Transform Transform => transform;
    }
}