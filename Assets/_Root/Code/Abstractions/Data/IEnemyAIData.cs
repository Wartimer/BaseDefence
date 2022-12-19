namespace _Root.Code.Abstractions
{
    public interface IEnemyAIData
    {
        public float VisDistance { get; }
        public float VisAngle { get; }
        public float MeleeDist { get; }
    }
}