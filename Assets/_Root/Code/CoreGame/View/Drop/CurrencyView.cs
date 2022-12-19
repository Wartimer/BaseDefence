using System.Collections.Generic;
using _Root.Code.Abstractions;
using UnityEngine;

namespace _Root.Code.Utility
{
    internal class CurrencyView : MonoBehaviour, IDropedCurrency
    {
        
        [SerializeField] private CurrencyType _type;
        [SerializeField] private int _amount;
        private List<IInGameObserver<IDropedCurrency>> _observers; 
        
        public CurrencyType Type => _type;
        public int Amount => _amount;

        public GameObject View => gameObject;
        
        public void AddObserver(IInGameObserver<IDropedCurrency> o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IInGameObserver<IDropedCurrency> o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers(IDropedCurrency value)
        {
            // for (int i = 0; i < _observers.Count; i++)
            // {
            //     _observers[i].ObserverUpdate(value);
            // }
        }
    }
}