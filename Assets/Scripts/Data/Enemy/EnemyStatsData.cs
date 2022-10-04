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

        public float Hp => _hp;
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float StoppingDistance => _stopingDistance;
    }
}
