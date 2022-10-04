using Enemy;
using Enemy.Interfaces;
using Interfaces;
using UnityEngine;

namespace Data
{
    internal interface IEnemy : IHaveAI, IHaveAnimation, IHaveStates, IHaveTarget, IAttacker
    {

    }
}