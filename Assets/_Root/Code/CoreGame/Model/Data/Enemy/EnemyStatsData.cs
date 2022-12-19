using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyStatsData", menuName = "Data/EnemyStatsData")]
    public class EnemyStatsData : ScriptableObject
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _stopingDistance;
        [SerializeField] private float _visDist;
        [SerializeField] private float _visAngle;
        [SerializeField] private float _meleeDist;
        [SerializeField] private float _combatRotSpeed;
        

        public float Hp => _hp;
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float StoppingDistance => _stopingDistance;
        public float VisDistance => _visDist;
        public float VisAngle => _visAngle;
        public float MeleeDist => _meleeDist;
        
        public float CombatRotSpeed => _combatRotSpeed;
    }
}
