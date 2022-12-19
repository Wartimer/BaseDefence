using _Root.Code.Abstractions;
using UnityEngine;

namespace _Root.Code.Data
{
    [CreateAssetMenu(fileName = "EnemyAIData", menuName = "Data/" + nameof(EnemyAIData))]
    public class EnemyAIData : ScriptableObject, IEnemyAIData
    {
        [SerializeField] private float _visDist;
        [SerializeField] private float _visAngle;
        [SerializeField] private float _meleeDist;
        
        public float VisDistance => _visDist;
        public float VisAngle => _visAngle;
        public float MeleeDist => _meleeDist;
    }
}
