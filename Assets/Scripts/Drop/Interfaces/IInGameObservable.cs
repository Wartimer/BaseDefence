namespace Interfaces
{
    internal interface IInGameObservable<T,U>
    {
        void AddObserver(T o);
        void RemoveObserver(T o);
        void NotifyObservers(U value);
    }
}