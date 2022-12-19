using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Utility
{
    internal interface IAssetLoader<T>
    {
        public AsyncOperationHandle<T> LoadAsset(AssetReference assetReference);

        public void UnloadAsset(AssetReference assetReference, T asset);
    }
}