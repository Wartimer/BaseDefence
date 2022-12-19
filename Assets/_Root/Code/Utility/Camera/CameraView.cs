using Cinemachine;
using UnityEngine;

namespace GameCamera
{
    internal class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private Camera _mainCamera;

        public Camera MainCamera => _mainCamera;
        public CinemachineVirtualCamera CinemachineVirtualCamera => _cinemachineVirtualCamera;

        public void Init(Transform target, CameraData data)
        {
            _cinemachineVirtualCamera.Follow = target;
            _cinemachineVirtualCamera.LookAt = target;
            _cinemachineVirtualCamera.m_Lens.FieldOfView = data.VerticalFOV;
            
        }
    }
}