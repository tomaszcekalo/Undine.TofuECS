using System;
using System.Collections.Generic;
using System.Text;
using Tofunaut.TofuECS;
using Undine.Core;
using Undine.Core.Unmanaged;

namespace Undine.TofuECS
{
    public class TofuEntity : IUnmanagedEntity
    {
        private Simulation _simulation;

        public TofuEntity(Simulation simulation)
        {
            this._simulation = simulation;
        }

        public int Id { get; internal set; }

        public void AddComponent<A>(in A component) where A : unmanaged
        {
            _simulation.Buffer<A>().Set(Id, component);
        }

        public unsafe ref A GetComponent<A>() where A : unmanaged
        {
            var buffer = _simulation.Buffer<A>();
            var i = 0;

            buffer.GetUnsafe(Id, out var bComponent);
            return ref *bComponent;
        }
    }
}