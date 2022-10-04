using Siva.Tool.ResourceManagement;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/UIData", fileName = "UIData", order = 0)]
    internal class UIData : ScriptableObject
    {
        [Header("BaseUI")] 
        [SerializeField] private AssetReference _placeForUi;
        [SerializeField] private AssetReference _placeForVirtualInputs;
        [SerializeField] private AssetReference _virtualJoystickMove;

        public GameObject PlaceForUi => AddressablesLoader.LoadGameObject(_placeForUi);
        public UICanvasControllerInput PlaceForVirtualJoysticks => AddressablesLoader.LoadGameObject(_placeForVirtualInputs).GetComponent<UICanvasControllerInput>();
        public UIVirtualJoystick VirtualJoystick => AddressablesLoader.LoadGameObject(_virtualJoystickMove).GetComponent<UIVirtualJoystick>();

    }
}