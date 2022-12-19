using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Siva.Tool.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(Data), menuName = "Data" + nameof(Data))]
    internal class Data : ScriptableObject
    {
        [Header("Data")] 
        [SerializeField] private AssetReference _playerData;
        [SerializeField] private AssetReference _cameraData;
        [SerializeField] private AssetReference _uiData;
        [SerializeField] private AssetReference _enemyDataList;
        [SerializeField] private AssetReference _mapData;
        
        
        public PlayerData PlayerData => GetData<PlayerData>(_playerData);
        public CameraData CameraData => GetData<CameraData>(_cameraData);
        public UIData UIData => GetData<UIData>(_uiData);
        public EnemyDataList EnemyDataList => GetData<EnemyDataList>(_enemyDataList);
        
        public MapData MapData => GetData<MapData>(_mapData);
        

        private T GetData<T>(AssetReference assetReference) where T : Object =>
            AddressablesLoader.LoadDataAssetAsync(assetReference).WaitForCompletion() as T;
        
        
        public void LoadScene(AssetReference assetReference, LoadSceneMode mode)
        {
            AddressablesLoader.LoadSceneAsync(assetReference, mode);
        }
        
        public void UnloadDataAsset(AssetReference assetReference, Object asset)
        {
            AddressablesLoader.RemoveDataAsset(assetReference, asset);
        }

        public void UnloadScene(SceneInstance scene)
        {
            AddressablesLoader.UnloadScene(scene);
        }
    }
}