using UnityEngine;

namespace Interfaces
{
    internal interface ITarget
    {
        public int Priority { get; }
        public Transform Transform { get; }
    }
}