using _Root.Code.Abstractions.Data;

namespace _Root.Code.Abstractions
{
    public class PlayerBase : IPlayer
    {
        public IPlayerData Data { get; }
    }
}