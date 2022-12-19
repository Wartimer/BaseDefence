using _Root.Code.Abstractions;
using Player;

namespace _Root.Code.Abstractions
{
    public class PlayerBase : IPlayer
    {
        public IPlayerData Data { get; }
        public PlayerViewBase View { get; }
        
    }
}