using UnityEngine;

namespace _Root.Code.Abstractions
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider))]
    public abstract class EnemyViewBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private CapsuleCollider _collider;
        private Animator _animator;
        private BoxCollider _boxCollider;

        private float _damage;

        public Rigidbody Rigidbody
        {
            get
            {
                if (_rigidbody == null)
                {
                    _rigidbody = gameObject.GetComponent<Rigidbody>();
                }

                return _rigidbody;
            }
        }
        
        public CapsuleCollider Collider
        {
            get
            {
                if (_collider == null)
                {
                    _collider = gameObject.GetComponent<CapsuleCollider>();
                }

                return _collider;
            }
        }
        
        public Animator Animator
        {
            get
            {
                if(_animator == null)
                {
                    _animator = gameObject.GetComponent<Animator>();
                }

                return _animator;
            }
        }
        
        public BoxCollider BoxCollider
        {
            get
            {
                if (_boxCollider == null)
                {
                    _boxCollider = gameObject.GetComponent<BoxCollider>();
                }

                return _boxCollider;
            }
        }

    }
}