using System;
using UnityEngine;
using Interfaces;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Pools
{
    public abstract class PoolBase<T> : IDisposable
    {
        protected int PoolCapacity { get; }
        protected Transform Root { get; }
        protected Stack<T> ObjectPool { get; }

        protected PoolBase(int poolCapacity, Transform root)
        {
            PoolCapacity = poolCapacity;
            Root = root;
            ObjectPool = new Stack<T>();
        }

        public abstract T GetObject();

        public abstract void ReturnToPool(T obj);

        public virtual void Dispose()
        {
            ObjectPool.Clear();
        }
    }
}