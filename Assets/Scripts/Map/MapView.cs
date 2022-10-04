using System.Collections.Generic;
using System.Linq;
using Spawner;
using UnityEngine;

namespace Map
{
    internal class MapView : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPos;
        [SerializeField] private List<SpawnerView> _spawners;
        [SerializeField] private List<Point> _attackPoints;  

        public Transform PlayerSpawnPos => playerSpawnPos;
        public List<SpawnerView> Spawners => _spawners;
        public List<Point> AttackPoints => _attackPoints;

#if UNITY_EDITOR
        [SerializeField] private SpawnerView spawnerPrefab;
        [SerializeField] private Transform parent;

        
        private void OnDrawGizmos()
        {
            // if (playerSpawnPos != null)
            // {
            //     Gizmos.DrawIcon(playerSpawnPos.position + new Vector3(0, 1, 0), "Pin.png", true);
            // }

            playerSpawnPos.position = new Vector3(playerSpawnPos.position.x, 0,
                playerSpawnPos.position.z);
            
            _spawners.Where(x => x == null).ToList().ForEach(x => _spawners.Remove(x));

            if (_spawners.Count > 0)
            {
                _spawners.Where(x => x != null).ToList().ForEach(x =>
                {
                    var position = x.RectTransform.position;
                    var color = Color.red;
                    Gizmos.DrawIcon(position, "Portal.png");
                    Gizmos.color = color;

                    var rect = x.RectTransform.rect;
                    Gizmos.DrawWireCube(new Vector3(position.x, 0.1f, position.z),
                        new Vector3(rect.width, 0, rect.height));

                    // 
                });
            }
        }
#endif

    }
}