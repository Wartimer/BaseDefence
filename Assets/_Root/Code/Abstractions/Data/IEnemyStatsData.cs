namespace _Root.Code.Abstractions
{
    public interface IEnemyStatsData
    {
        public float Hp { get; }
        public int Damage { get; }
        public float WalkSpeed { get; }
        public float RunSpeed { get; }
        public float CombatRotSpeed { get; }
    }
}