
using Player;
using System;
using _Root.Code.Abstractions;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyView : EnemyViewBase, IViewProvider

    {
    public EnemyView View { get; private set; }

    }
}