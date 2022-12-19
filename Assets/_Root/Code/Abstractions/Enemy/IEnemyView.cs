using UnityEngine;

namespace _Root.Code.Abstractions
{
    public interface IEnemyView
    {
        public Rigidbody Rigidbody { get; }
        public CapsuleCollider Collider { get; }
        public Animator Animator { get; }
        public BoxCollider BoxCollider { get; }
    }
}