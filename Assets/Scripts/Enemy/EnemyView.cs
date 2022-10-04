using Data.Abilities;
using Interfaces;
using Player;
using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyView : MonoBehaviour, IDamagable
    {
        public Action OnDamageFromPlayerReceived;   // убрать
        public Action OnShot;                       // в контроллер, метод урона заприватить
        
        private Rigidbody _rigidbody;
        private CapsuleCollider _collider;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private BoxCollider _boxCollider;
        private BaseAttack _currentAttack;

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
        public BaseAttack CurrentAttack
        {
            get => _currentAttack;
            set => _currentAttack = value;
        }

        public float Damage
        {
            get => _damage;
            set => _damage = value;
        } 

        #region Animation Events
        public void EnableDamageColliderAnimEvent()
        {
            BoxCollider.enabled = true;
        }
        public void DisableDamageColliderAnimEvent()
        {
            BoxCollider.enabled = false;
        }
        
        public void ShotEvent()
        {
            OnShot?.Invoke();
        }
        #endregion

        public AudioClip[] FootstepAudioClips;
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;
        
        
        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.position, FootstepAudioVolume);
                }
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            // var isHit = other.TryGetComponent(out PlayerView playerView);
            // if (isHit && !other.isTrigger)
            // {
            //     playerView.InflictDamage(_currentAttack.Dmg);
            // }
                
        }
        public void InflictDamage(float damage)
        {
            _damage = damage;
            OnDamageFromPlayerReceived?.Invoke();           
        }
        
    }
}