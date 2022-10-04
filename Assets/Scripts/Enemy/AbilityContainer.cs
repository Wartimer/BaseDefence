using System;
using System.Collections.Generic;
using Data.Abilities;

namespace Enemy
{
    public class AbilityContainer
    {
        private readonly Dictionary<string, AbilityBase> _abilities;

        public AbilityContainer(Dictionary<string, AbilityBase> abilities)
        {
            _abilities = abilities;
        }
    }
}