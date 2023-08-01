﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Core.Unmanaged
{
    //public class UnmanagedUnifiedSystem
    //{
    //}

    public abstract class UnmanagedUnifiedSystem<T> : UnifiedSystem, IUnifiedSystem<T>
        where T : unmanaged

    {
        public abstract void ProcessSingleEntity(int entityId, ref T t);
    }

    public abstract class UnmanagedUnifiedSystem<A, B> : UnifiedSystem, IUnifiedSystem<A, B>
        where A : unmanaged
        where B : unmanaged
    {
        public abstract void ProcessSingleEntity(int entityId, ref A a, ref B b);
    }

    public abstract class UnmanagedUnifiedSystem<A, B, C> : UnifiedSystem, IUnifiedSystem<A, B, C>
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
    {
        public abstract void ProcessSingleEntity(int entityId, ref A a, ref B b, ref C c);
    }

    public abstract class UnmanagedUnifiedSystem<A, B, C, D> : UnifiedSystem, IUnifiedSystem<A, B, C, D>
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
    {
        public abstract void ProcessSingleEntity(int entityId, ref A a, ref B b, ref C c, ref D d);
    }
}