using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Core.Unmanaged
{
    //public interface IUnmanagedEcsContainer
    //{
    //}
    public interface IUnmanagedEcsContainer : IEcsContainer
    {
        void AddSystem<A>(UnmanagedUnifiedSystem<A> system)
        where A : unmanaged;

        void AddSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
        where A : unmanaged
        where B : unmanaged;

        void AddSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged;

        void AddSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged;

        ISystem GetSystem<A>(UnmanagedUnifiedSystem<A> system)
        where A : unmanaged;

        ISystem GetSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
        where A : unmanaged
        where B : unmanaged;

        ISystem GetSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged;

        ISystem GetSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged;
    }
}