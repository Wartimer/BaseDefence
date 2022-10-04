using UnityEngine;

namespace Data.Abilities
{
    public abstract class AbilityBase : ScriptableObject
    {
        [SerializeField] private string abilityName;

        public string AbilityName => abilityName;
    }
}