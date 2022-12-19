using System.Collections.Generic;
using _Root.Code.Abstractions.Enums;

namespace Inventory
{
    internal class InventoryController
    {
        private Dictionary<CurrencyType, int> _currencies;

        public void AddCurrency(IDropedCurrency dropedCurrency)=>
            _currencies[dropedCurrency.Type] += dropedCurrency.Amount;
        

    }
}