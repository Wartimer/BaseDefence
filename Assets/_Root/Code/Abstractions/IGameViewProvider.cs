
namespace _Root.Code.Abstractions
{
    public interface IGameViewProvider<out T>
    {
        T View { get; }
    }
}