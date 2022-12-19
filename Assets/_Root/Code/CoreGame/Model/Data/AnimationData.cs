using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Data/AnimationData")]
    public class AnimationData : ScriptableObject
    {
        [SerializeField] private string _sleepAnimation;
        [SerializeField] private string _wakeAnimation;
        [SerializeField] private string _flinchAnimation;
        [SerializeField] private string _knockdownAnimation;
        [SerializeField] private string _deathAnimation;

        public string SleepAnimation => _sleepAnimation;
        public string WakeAnimation => _wakeAnimation;
        public string FlinchAnimation => _flinchAnimation;
        public string KnockdownAnimation => _knockdownAnimation;
        public string DeathAnimation => _deathAnimation;
    }
}