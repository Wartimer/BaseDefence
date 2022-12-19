using System.Collections.Generic;

namespace _Root.Code.Abstractions
{
    public interface IInteractablesManager<T>
    {
        List<T> LootContainers { get; }
    }
}