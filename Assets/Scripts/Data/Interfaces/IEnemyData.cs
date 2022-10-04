using Enemy;
using Spawner;

namespace Data
{
    public interface IEnemyData
    {
        EnemyType Type { get; }
        EnemyView EnemyView { get; }
        EnemyStatsData EnemyStatsData { get; }
        EnemyAIData EnemyAIData { get; }
        AnimationData EnemyAnimData { get; }
    }
}