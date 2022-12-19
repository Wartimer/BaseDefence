using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using _Root.Code.Abstractions;

namespace _Root.Code.Utility
{
    internal class DroppedCurrencyContainer : IInGameObserver<IDropedCurrency>, IDisposable
    {
        private List<IDropedCurrency> _droppedItems;
        
        private InventoryController _inventory;

        internal DroppedCurrencyContainer(InventoryController inventory)
        {
            _droppedItems = new List<IDropedCurrency>();
        }

        public void ObserverUpdate(IDropedCurrency currency)
        {
            var pickUpCurency = _droppedItems.FirstOrDefault(o => o == currency);
            if (pickUpCurency == null) return;
            
            _inventory.AddCurrency(pickUpCurency);
            pickUpCurency.RemoveObserver(this);
            _droppedItems.Remove(pickUpCurency);
            Object.Destroy(pickUpCurency.View);
        }

        public void AddItemToDrop(IDropedCurrency currencyView)
        {
            _droppedItems.Add(currencyView);
            currencyView.AddObserver(this);
        }
        
        public void Dispose()
        {
            
        }
        
    }
}

