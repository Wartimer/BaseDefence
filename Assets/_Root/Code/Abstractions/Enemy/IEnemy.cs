namespace _Root.Code.Abstractions
{
    public interface IEnemy : IHaveAI, IHaveAnimation, 
                                IHaveStates, IHaveTarget, 
                                    IGameViewProvider<EnemyViewBase>, IPlayerProvider
    {
        public IEnemyData EnemyData { get; }
        public EnemyViewBase View { get; }
    }
}