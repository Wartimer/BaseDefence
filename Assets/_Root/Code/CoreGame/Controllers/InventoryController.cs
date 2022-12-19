using System.Collections.Generic;
using Drop;

namespace Inventory
{
    internal class InventoryController
    {
        private Dictionary<CurrencyType, int> _currencies;

        public void AddCurrency(IDropedCurrency dropedCurrency)=>
            _currencies[dropedCurrency.Type] += dropedCurrency.Amount;
        

    }
}