using Data;
using Interfaces;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    internal class MyPlayer 
    {
        public PlayerData Data { get; }
        private PlayerView _view;
        
        public PlayerView PlayerView => _view;
        public GameObject PlayerGameObject => _view.gameObject;
        
        private float _hp;

        private ThirdPersonController _playerControl;
        private StarterAssetsInputs _starterAssetsInputs;
        public StarterAssetsInputs StarterAssetsInputs => _starterAssetsInputs;

        public MyPlayer(PlayerData data)
        {
            Data = data;
        }

        public void Spawn(Transform spawnTransform)
        {
            _hp = Data.Health;
            _view = Data.PlayerView;

            if (_view.TryGetComponent(out ThirdPersonController control))
                _playerControl = control;
            if (_view.TryGetComponent(out StarterAssetsInputs starterAssetsInputs))
                _starterAssetsInputs = starterAssetsInputs;

            _view.transform.position = spawnTransform.position;
            _view.OnDamageFromEnemyReceived += Damage;
            _view.OnDeath += Death;
            _view.BoxCollider.enabled = false;
        }

        private void Damage()
        {

        }

        private void Death()
        {
            // _animController.PlayAnimation(Data.PlayerAnimationData.DeathAnimation, true);
            _view.IsDead = true;
            _view.Rigidbody.velocity = Vector3.zero;
            _view.Rigidbody.angularVelocity = Vector3.zero;
        }
    }
}