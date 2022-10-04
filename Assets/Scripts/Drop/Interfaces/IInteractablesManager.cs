using System.Collections.Generic;

namespace Interfaces
{
    public interface IInteractablesManager<T>
    {
        List<T> LootContainers { get; }
    }
}