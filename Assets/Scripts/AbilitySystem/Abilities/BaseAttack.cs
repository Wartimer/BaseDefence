using UnityEngine;

namespace Data.Abilities
{
    [CreateAssetMenu(fileName = "BaseAttack", menuName = "Abilities/BaseAttack", order = 0)]
    public class BaseAttack : AbilityBase
    {
        [SerializeField] private int _dmg;
        [SerializeField] private int _priority;
        [SerializeField] private int _recovery;
        [SerializeField] private float _angle;
        [SerializeField] private float _minimumDistance;
        [SerializeField] private float _maximumDistance;
        [SerializeField] private string _animation;
        [SerializeField] private bool _isRunningAttack;
        [Header("Projectile")]
        [SerializeField] private float _projectileSpeed;
        [Header("Attack Hitbox")]
        [SerializeField] private float _x;
        [SerializeField] private float _y;
        [SerializeField] private float _z;


        public int Dmg => _dmg;
        public int Priority => _priority;
        public int Recovery => _recovery;
        public float Angle => _angle;
        public float MinimumDistance => _minimumDistance;
        public float MaximumDistance => _maximumDistance;
        public string Animation => _animation;
        public bool IsRunningAttack => _isRunningAttack;
        public float ProjectileSpeed => _projectileSpeed;
        public float X => _x;
        public float Y => _y;
        public float Z => _z;

        
    }
}