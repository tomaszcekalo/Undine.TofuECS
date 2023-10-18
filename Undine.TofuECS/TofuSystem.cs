using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;
using Tofunaut.TofuECS;
using Undine.Core.Unmanaged;

namespace Undine.TofuECS
{
    public class TofuSystem<A> : Core.ISystem, Tofunaut.TofuECS.ISystem
        where A : unmanaged
    {
        protected Simulation _simulation;

        public UnifiedSystem<A> System { get; set; }

        public void Initialize(Simulation s)
        {
            this._simulation = s;
        }

        public void Process(Simulation s)
        {
            var buffer = s.Buffer<A>();
            var i = 0;
            while (buffer.Next(ref i, out int entityId, out var someValueComponent))
            {
                System.ProcessSingleEntity(entityId, ref someValueComponent);
            }
        }

        public void ProcessAll()
        {
            Process(this._simulation);
        }
    }

    public class TofuSystem<A, B> : Core.ISystem, Tofunaut.TofuECS.ISystem
        where A : unmanaged
        where B : unmanaged
    {
        protected Simulation _simulation;

        public UnifiedSystem<A, B> System { get; set; }

        public void Initialize(Simulation s)
        {
            this._simulation = s;
        }

        public unsafe void Process(Simulation s)
        {
            var buffer = s.Buffer<A>();
            var bufferB = s.Buffer<B>();
            var i = 0;
            while (buffer.Next(ref i, out int entityId, out var aComponent))
            {
                bufferB.GetUnsafe(entityId, out var bComponent);
                System.ProcessSingleEntity(entityId, ref aComponent, ref *bComponent);
                buffer.Set(entityId, aComponent);
                bufferB.Set(entityId, *bComponent);
            }
        }

        public void ProcessAll()
        {
            Process(this._simulation);
        }
    }

    public class TofuSystem<A, B, C> : Core.ISystem, Tofunaut.TofuECS.ISystem
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
    {
        protected Simulation _simulation;

        public UnifiedSystem<A, B, C> System { get; set; }

        public void Initialize(Simulation s)
        {
            this._simulation = s;
        }

        public unsafe void Process(Simulation s)
        {
            var buffer = s.Buffer<A>();
            var bufferB = s.Buffer<B>();
            var bufferC = s.Buffer<C>();
            var i = 0;
            while (buffer.Next(ref i, out int entityId, out var aComponent))
            {
                bufferB.GetUnsafe(entityId, out var bComponent);
                bufferC.GetUnsafe(entityId, out var cComponent);
                System.ProcessSingleEntity(entityId, ref aComponent, ref *bComponent, ref *cComponent);
                buffer.Set(entityId, aComponent);
                bufferB.Set(entityId, *bComponent);
                bufferC.Set(entityId, *cComponent);
            }
        }

        public void ProcessAll()
        {
            Process(this._simulation);
        }
    }

    public class TofuSystem<A, B, C, D> : Core.ISystem, Tofunaut.TofuECS.ISystem
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
    {
        protected Simulation _simulation;

        public UnifiedSystem<A, B, C, D> System { get; set; }

        public void Initialize(Simulation s)
        {
            this._simulation = s;
        }

        public unsafe void Process(Simulation s)
        {
            var buffer = s.Buffer<A>();
            var bufferB = s.Buffer<B>();
            var bufferC = s.Buffer<C>();
            var bufferD = s.Buffer<D>();
            var i = 0;
            while (buffer.Next(ref i, out int entityId, out var aComponent))
            {
                bufferB.GetUnsafe(entityId, out var bComponent);
                bufferC.GetUnsafe(entityId, out var cComponent);
                bufferD.GetUnsafe(entityId, out var dComponent);
                System.ProcessSingleEntity(entityId, ref aComponent, ref *bComponent, ref *cComponent, ref *dComponent);
                buffer.Set(entityId, aComponent);
                bufferB.Set(entityId, *bComponent);
                bufferC.Set(entityId, *cComponent);
                bufferD.Set(entityId, *dComponent);
            }
        }

        public void ProcessAll()
        {
            Process(this._simulation);
        }
    }
}