namespace _Root.Code.Abstractions
{
    public interface IInGameObservable<T,U>
    {
        void AddObserver(T o);
        void RemoveObserver(T o);
        void NotifyObservers(U value);
    }
}