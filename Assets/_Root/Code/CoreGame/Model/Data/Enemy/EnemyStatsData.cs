using _Root.Code.Abstractions;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Data/EnemyStatsData")]
    public class EnemyStatsData : ScriptableObject, IEnemyStatsData
    {
        [SerializeField] private float _hp;
        [SerializeField] private int _damage;
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _combatRotSpeed;
        
        public float Hp => _hp;
        public int Damage => _damage;
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float CombatRotSpeed => _combatRotSpeed;
    }
}
