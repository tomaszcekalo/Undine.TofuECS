using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.Core.StructBased
{
    public interface IStructBasedEcsContainer : IEcsContainer
    {
        void AddSystem<A>(StructBasedUnifiedSystem<A> system)
        where A : struct;

        void AddSystem<A, B>(StructBasedUnifiedSystem<A, B> system)
        where A : struct
        where B : struct;

        void AddSystem<A, B, C>(StructBasedUnifiedSystem<A, B, C> system)
        where A : struct
        where B : struct
        where C : struct;

        void AddSystem<A, B, C, D>(StructBasedUnifiedSystem<A, B, C, D> system)
        where A : struct
        where B : struct
        where C : struct
        where D : struct;

        ISystem GetSystem<A>(StructBasedUnifiedSystem<A> system)
        where A : struct;

        ISystem GetSystem<A, B>(StructBasedUnifiedSystem<A, B> system)
        where A : struct
        where B : struct;

        ISystem GetSystem<A, B, C>(StructBasedUnifiedSystem<A, B, C> system)
        where A : struct
        where B : struct
        where C : struct;

        ISystem GetSystem<A, B, C, D>(StructBasedUnifiedSystem<A, B, C, D> system)
        where A : struct
        where B : struct
        where C : struct
        where D : struct;
    }
}