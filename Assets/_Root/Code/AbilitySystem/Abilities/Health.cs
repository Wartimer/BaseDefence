using UnityEngine;

namespace Data.Abilities
{
    [CreateAssetMenu(fileName = "Heath", menuName = "Abilities/Health")]
    public class Health : AbilityBase
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject healthBar;

        public int MaxHealth => maxHealth;
        public GameObject HealthBar => healthBar;
    }
}