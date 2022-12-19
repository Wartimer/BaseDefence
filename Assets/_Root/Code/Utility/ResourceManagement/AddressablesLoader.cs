using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Utility
{
    public static class AddressablesLoader
    {
        private static readonly Dictionary<AssetReference, List<Object>> _loadedDataAssets =
            new Dictionary<AssetReference, List<Object>>();

        private static readonly Dictionary<AssetReference, List<GameObject>> _spawnedGameObjects =
            new Dictionary<AssetReference, List<GameObject>>();

        private static readonly Dictionary<AssetReference, AsyncOperationHandle<Object>> _dataOperationHandles =
            new Dictionary<AssetReference, AsyncOperationHandle<Object>>();

        private static readonly Dictionary<AssetReference, AsyncOperationHandle<GameObject>> _goAsyncOperationHandles =
            new Dictionary<AssetReference, AsyncOperationHandle<GameObject>>();
        
        public static AsyncOperationHandle<Object> LoadDataAssetAsync(AssetReference assetReference)
        {
            var op = Addressables.LoadAssetAsync<Object>(assetReference);
            _dataOperationHandles[assetReference] = op;

            op.Completed += (operation) =>
            {
                if (!_loadedDataAssets.ContainsKey(assetReference))
                    _loadedDataAssets[assetReference] = new List<Object>();
                _loadedDataAssets[assetReference].Add(operation.Result);
            };
            return op;
        }

        public static AsyncOperationHandle<GameObject> LoadGameObjectAsync(AssetReference assetReference)
        {
            var op = assetReference.InstantiateAsync();
            
            _goAsyncOperationHandles[assetReference] = op;
            
            if (!_spawnedGameObjects.ContainsKey(assetReference))
                _spawnedGameObjects[assetReference] = new List<GameObject>();
                    
            _spawnedGameObjects[assetReference].Add(op.Result);

            var notify = op.Result.AddComponent<NotifyOnDestroy>();
            notify.AssetReference = assetReference;
            notify.Destroyed += RemoveGameObject;

            return op;
        }

        public static GameObject LoadGameObject(AssetReference assetReference)
        {
            var op = assetReference.InstantiateAsync();
            _goAsyncOperationHandles[assetReference] = op;
            
            var notify = op.WaitForCompletion().AddComponent<NotifyOnDestroy>();
            if (!_spawnedGameObjects.ContainsKey(assetReference))
                _spawnedGameObjects[assetReference] = new List<GameObject>();
            _spawnedGameObjects[assetReference].Add(op.Result);
            
            notify.AssetReference = assetReference;
            notify.Destroyed += RemoveGameObject;
            return notify.gameObject;
        }

        //This method unloads Asset and it's Handler
        public static void RemoveDataAsset(AssetReference assetReference, Object asset)
        {
            Addressables.Release(asset);
            _loadedDataAssets[assetReference].Remove(asset);
            Debug.Log($"Loaded assets dictionary count : {_loadedDataAssets.Count}");
            if (_loadedDataAssets[assetReference].Count == 0)
            {
                Debug.Log($"Removed all {assetReference.RuntimeKey}");
                if (_dataOperationHandles[assetReference].IsValid())
                    Addressables.Release(_dataOperationHandles[assetReference]);
                _dataOperationHandles.Remove(assetReference);
            }

            Debug.Log($"AssetReferences : {_loadedDataAssets.Count}");
        }
        
        private static void RemoveGameObject(AssetReference assetReference, NotifyOnDestroy obj)
        {
            Addressables.ReleaseInstance(obj.gameObject);
            _spawnedGameObjects[assetReference].Remove(obj.gameObject);
            if (_spawnedGameObjects[assetReference].Count == 0)
            {
                Debug.Log($"Removed all {assetReference.RuntimeKey.ToString()}");
            
                if (_goAsyncOperationHandles[assetReference].IsValid())
                    Addressables.Release(_goAsyncOperationHandles[assetReference]);

                _goAsyncOperationHandles.Remove(assetReference);
            }
        }

#region Scene Loading methods

        public static void LoadSceneAsync(AssetReference assetReference, LoadSceneMode mode)
        {
            var op = LoadLocations(assetReference);
            IResourceLocation location;

            op.Completed += (operation) =>
            {
                location = op.Result[0];
                var op2 = Addressables.LoadSceneAsync(location, mode);
                op2.Completed += (op3) =>
                {
                    Addressables.Release(op2);
                };
            };

            Addressables.Release(op);
        }
        
        public static void UnloadScene(SceneInstance scene)
        {
            var op = Addressables.UnloadSceneAsync(scene);
            op.Completed += context =>
            {
                Addressables.Release(op);
            };
        }

#endregion

        
        private static AsyncOperationHandle<IList<IResourceLocation>> LoadLocations(AssetReference assetReference)
        {
            var op = Addressables.LoadResourceLocationsAsync(assetReference);

            op.Completed += (operation) =>
            {
                if (op.Result.Count > 1)
                    throw new Exception($"There are several locations for {assetReference.Asset.name}");
            };
            return op;
        }
        
    }
}