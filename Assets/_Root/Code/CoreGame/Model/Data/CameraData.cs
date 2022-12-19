using GameCamera;
using Siva.Tool.ResourceManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/CameraData", order = 0)]
    internal class CameraData : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField] private AssetReference _camera;

        [Header("Settings")] 
        [SerializeField] private float _verticalFOV;

        public float VerticalFOV => _verticalFOV;

        public CameraView Camera => AddressablesLoader.LoadGameObject(_camera).GetComponent<CameraView>();
    }
}