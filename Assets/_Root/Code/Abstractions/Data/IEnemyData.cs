
namespace _Root.Code.Abstractions
{
    public interface IEnemyData
    {
        EnemyType Type { get; }
        IEnemy EnemyView { get; }
        IEnemyStatsData EnemyStatsData { get; }
        IEnemyAIData EnemyAIData { get; }
    }
}