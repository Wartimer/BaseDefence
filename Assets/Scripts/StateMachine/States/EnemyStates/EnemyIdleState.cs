using System;
using Enemy;
using Interfaces;
using UnityEngine;

namespace UnitBehavior
{
    internal sealed class EnemyIdleState: State
    {
        private SimpleEnemy _enemy;
        private float _firstScan = 0;
        private float _timeToNextScon = 0.6f;

        public EnemyIdleState(SimpleEnemy enemy)
        {
            _enemy = enemy;
        }
        
        public override void Enter()
        {
            base.Enter();
            _enemy.EnemyAnimator.SetFloat(_enemy.SpeedId, 0);
        }
        
        public override void Exit()
        {
            
        }

        public override void Update(float deltaTime)
        {
            _firstScan += deltaTime;
            if(_firstScan >= _timeToNextScon)
            {
                ScanForTargets();
                _firstScan = 0;
            }
        }

        private void ScanForTargets()
        {
            var colliders = new Collider[10];
            
            Physics.OverlapSphereNonAlloc(_enemy.View.transform.position, 4, colliders);

            if (colliders[0] == null) return;

            var targetsArray = new ITarget[colliders.Length];
            
            int j = 0;
            for (var i = 0; i < colliders.Length - 1; i++)
            {
                if (colliders[i] == null) continue;
                if (colliders[i].TryGetComponent(out ITarget pl))
                {
                    targetsArray[j] = pl;
                    j++;
                }
            }
            
            if (targetsArray[0] == null) return;
            
            Array.Resize(ref targetsArray, j);
            
            var sortedTargets = SortArray(targetsArray, 0, targetsArray.Length-1);

            var chosenTarget = sortedTargets[0];
            _enemy.SetTarget(chosenTarget);
        }

        private ITarget[] SortArray(ITarget[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;

            var pivot = array[leftIndex];
            
            while (i <= j)
            {
                while (array[i].Priority > pivot.Priority)
                {
                    i++;
                }
        
                while (array[j].Priority < pivot.Priority)
                {
                    j--;
                }

                if (i > j) continue;
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
    
            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }
    }
}