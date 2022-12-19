using Player;

namespace _Root.Code.Abstractions
{
    public interface IPlayer
    {
        public IPlayerData Data { get; }
        public PlayerViewBase View { get; }
    }
}