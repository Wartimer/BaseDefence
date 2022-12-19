using System;

namespace _Root.Code.Abstractions
{
    internal interface IDropCurrency
    {
        event Action<IDropedCurrency, IDropCurrency> ItemDropped;
        
    }
}