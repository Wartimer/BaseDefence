using System;
using _Root.Code.Abstractions;
using Inventory;
using UnityEngine;

namespace InteractiveObjects
{
    public sealed class PlayerPickUp: MonoBehaviour
    {
        /// <summary>
        /// Ad this component to empty game object with Trigger box collider in Player prefab hierarhy
        /// </summary>
        public event Action<IInteractable> InteractableEntered;
        
        [SerializeField] private BoxCollider _pickUpCollider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable droppedItem))
            {
                Debug.Log(droppedItem);
                InteractableEntered?.Invoke(droppedItem);
            }
        }
    }
}