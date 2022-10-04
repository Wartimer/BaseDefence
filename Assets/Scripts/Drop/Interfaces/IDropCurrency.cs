using System;
using InteractiveObjects;

namespace Interfaces
{
    internal interface IDropCurrency
    {
        event Action<IDropedCurrency, IDropCurrency> ItemDropped;
        
    }
}