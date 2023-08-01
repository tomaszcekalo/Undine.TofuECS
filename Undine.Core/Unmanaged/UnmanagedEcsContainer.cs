using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Core.Unmanaged
{
    public abstract class UnmanagedEcsContainer : EcsContainer, IUnmanagedEcsContainer
    {
        public abstract void AddSystem<A>(UnmanagedUnifiedSystem<A> system) where A : unmanaged;

        public abstract void AddSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
            where A : unmanaged
            where B : unmanaged;

        public abstract void AddSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged;

        public abstract void AddSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged;

        public abstract ISystem GetSystem<A>(UnmanagedUnifiedSystem<A> system) where A : unmanaged;

        public abstract ISystem GetSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
            where A : unmanaged
            where B : unmanaged;

        public abstract ISystem GetSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged;

        public abstract ISystem GetSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged;
    }
}