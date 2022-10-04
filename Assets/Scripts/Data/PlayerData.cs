using Player;
using Siva.Tool.ResourceManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/" + nameof(PlayerData), order = 0)]
    internal class PlayerData : ScriptableObject
    {
        [SerializeField] private AssetReference _playerView;
        [SerializeField] private AnimationData _playerAnimationData;
        [SerializeField] private float health;
        [SerializeField] private int speed;

        public PlayerView PlayerView => AddressablesLoader.LoadGameObject(_playerView).GetComponent<PlayerView>();
        
        public AnimationData PlayerAnimationData => _playerAnimationData;

        public float Health => health;

        public int Speed => speed;
        
        
    }
}