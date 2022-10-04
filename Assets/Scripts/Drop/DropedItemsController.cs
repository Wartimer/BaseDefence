using System;
using Inventory;
using System.Collections.Generic;
using Interfaces;
using Runtime.Controller;
using UnityEngine;


namespace InteractiveObjects
{
    internal sealed class DroppedItemsController: IDisposable, IExecute
    {
        private DroppedCurrencyContainer _droppedCurrenciesContainer;
        
        internal DroppedItemsController(InventoryController inventory)
        {
           
            _droppedCurrenciesContainer = new DroppedCurrencyContainer(inventory);
            
        }
        
        private void AddItemsToDropContainer(IDropedCurrency droppedDropedCurrency, IDropCurrency container)
        {
            if (droppedDropedCurrency is DropedCurrencyView currency)
            {
                container.ItemDropped -= AddItemsToDropContainer;

                _droppedCurrenciesContainer.AddItemToDrop(currency);
                if(currency.TryGetComponent(out Rigidbody rb))
                    rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
            
        }
        
        public void Dispose()
        {
            
        }

        public void Execute()
        {
            
        }
    }
}
