using _Root.Code.Abstractions;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    
    public abstract class PlayerViewBase : MonoBehaviour
    {
        protected Rigidbody _rigidbody;
        protected Animator _animator;
        protected CapsuleCollider _capsuleCollider;
        protected BoxCollider _boxCollider;
        
        public Rigidbody Rigidbody => _rigidbody ? _rigidbody : (_rigidbody = gameObject.GetComponent<Rigidbody>());
        public Animator Animator => _animator ? _animator : (_animator = gameObject.GetComponent<Animator>());
        public CapsuleCollider CapsuleCollider => _capsuleCollider ? _capsuleCollider : (_capsuleCollider = gameObject.GetComponent<CapsuleCollider>());
        public BoxCollider BoxCollider => _boxCollider ? _boxCollider : (_boxCollider = gameObject.GetComponent<BoxCollider>());
        
        private void OnTriggerEnter(Collider other)
        {
            var isHit = other.TryGetComponent(out IEnemy enemyView);            
            if (isHit && !other.isTrigger)
            {
                
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                
            }
        }
    }
}