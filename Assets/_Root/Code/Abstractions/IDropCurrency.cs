using System;

namespace _Root.Code.Abstractions
{
    public interface IDropCurrency
    {
        event Action<IDropedCurrency, IDropCurrency> ItemDropped;
        
    }
}