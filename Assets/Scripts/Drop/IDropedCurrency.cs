

using Drop;
using UnityEngine;

namespace Interfaces
{
    internal interface IDropedCurrency : IInGameObservable<IInGameObserver<IDropedCurrency>, IDropedCurrency>
    {
        CurrencyType Type { get; }
        int Amount { get; }
        GameObject View { get; }
    }
}