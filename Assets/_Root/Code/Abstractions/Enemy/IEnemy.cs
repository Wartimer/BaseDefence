namespace _Root.Code.Abstractions
{
    public interface IEnemy : IHaveAI, IHaveAnimation, 
                                IHaveStates, IHaveTarget, IAttacker, 
                                    IGameViewProvider<EnemyViewBase>, IPlayerProvider
    {

    }
}