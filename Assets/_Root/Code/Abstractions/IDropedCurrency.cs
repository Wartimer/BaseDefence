using _Root.Code.Abstractions.Enums;
using UnityEngine;

namespace _Root.Code.Abstractions
{
    public interface IDropedCurrency : IInGameObservable<IInGameObserver<IDropedCurrency>, IDropedCurrency>
    {
        CurrencyType Type { get; }
        int Amount { get; }
        GameObject View { get; }
    }
}