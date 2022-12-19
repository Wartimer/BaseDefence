using UnityEngine;

namespace _Root.Code.Abstractions
{
    public interface ITarget
    {
        public int Priority { get; }
        public Transform Transform { get; }
    }
}