
namespace _Root.Code.Abstractions
{
    public interface IInGameObserver<T>
    {        
        void ObserverUpdate(T value);
    }
}
