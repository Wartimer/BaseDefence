using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs _starterAssetsInputs;

        public void Init(StarterAssetsInputs inputs) =>
            _starterAssetsInputs = inputs;
        
        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            _starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            _starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            _starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            _starterAssetsInputs.SprintInput(virtualSprintState);
        }
        
    }

}
