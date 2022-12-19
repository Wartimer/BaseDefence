using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyAIData", menuName = "Data/" + nameof(EnemyAIData))]
    public class EnemyAIData : ScriptableObject
    {
        [SerializeField] private float _detectionRadius;
        [SerializeField] private LayerMask _detectionLayer;
        [SerializeField] private float _fieldOfView;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _closeCombatThreshold;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _movementSpeedFactor;

        public float DetectionRadius => _detectionRadius;
        public LayerMask DetectionLayer => _detectionLayer;
        public float FieldOfView => _fieldOfView;
        public float AttackDistance => _attackDistance;
        public float CloseCombatThreshold => _closeCombatThreshold;
        public float RotationSpeed => _rotationSpeed;
        public float MovementSpeedFactor => _movementSpeedFactor;
    }
}
