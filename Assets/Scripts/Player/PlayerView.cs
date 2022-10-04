using System;
using UnityEngine;
using Interfaces;
using Enemy;
using InteractiveObjects;
using Unity.VisualScripting;


namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    
    internal class PlayerView : MonoBehaviour, IDamagable, ITarget, IInGameObservable<IInGameObserver<ITarget>, ITarget>
    {
        public event Action<IInteractable> PlayerTriggerStay;
        
        public Action OnDamageFromEnemyReceived;  //убрать в контроллер
        public Action OnDeath;                    //и заприватить метод урона
        
        private Rigidbody _rigidbody;
        private Animator _animator;
        private CapsuleCollider _capsuleCollider;
        private BoxCollider _boxCollider;

        private float _damage;
        private bool _isDead;
        
        /// <summary>
        /// Player pickup script reference
        /// </summary>
        [SerializeField] private PlayerPickUp _playerPickUp;
        public PlayerPickUp PlayerPickUp => _playerPickUp;

        [SerializeField] private int _priority;
        public int Priority => _priority;
        public Transform Transform => transform;
        
        public Rigidbody Rigidbody => _rigidbody ? _rigidbody : (_rigidbody = gameObject.GetOrAddComponent<Rigidbody>());
        public Animator Animator => _animator ? _animator : (_animator = gameObject.GetOrAddComponent<Animator>());
        public CapsuleCollider CapsuleCollider => _capsuleCollider ? _capsuleCollider : (_capsuleCollider = gameObject.GetOrAddComponent<CapsuleCollider>());
        public BoxCollider BoxCollider => _boxCollider ? _boxCollider : (_boxCollider = gameObject.GetOrAddComponent<BoxCollider>());
        
        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }
        public bool IsDead
        {
            get => _isDead;
            set => _isDead = value;
        }
        private void OnTriggerEnter(Collider other)
        {
            var isHit = other.TryGetComponent(out EnemyView enemyView);            
            if (isHit && !other.isTrigger)
            {
                enemyView.InflictDamage(2);
                Debug.Log("Inflicting damoage to Enemy: 2");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                PlayerTriggerStay?.Invoke(interactable);

            }
        }
        
        public void InflictDamage(float damage)
        {
            _damage = damage;
            OnDamageFromEnemyReceived?.Invoke();
        }
        
        public void AddObserver(IInGameObserver<ITarget> o)
        {
        
        }

        public void RemoveObserver(IInGameObserver<ITarget> o)
        {
            
        }

        public void NotifyObservers(ITarget value)
        {
            
        }
    }
}