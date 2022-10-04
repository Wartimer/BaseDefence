using GameCamera;
using Map;
using Siva.Tool.ResourceManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "MapData", menuName = "Data/" + nameof(MapData), order = 0)]
    internal sealed class MapData : ScriptableObject
    {
        [SerializeField] private AssetReference _mapView;

        public MapView Map => AddressablesLoader.LoadGameObject(_mapView).GetComponent<MapView>();
    }
}