using System;
using System.Collections.Generic;
using System.Text;
using Tofunaut.TofuECS;
using Undine.Core;
using Undine.Core.Unmanaged;

namespace Undine.TofuECS
{
    public class TestLogService : ILogService
    {
        public void Debug(string s) => Console.WriteLine($"[DEBUG] {s}");

        public void Info(string s) => Console.WriteLine($"[INFO] {s}");

        public void Warn(string s) => Console.WriteLine($"[WARN] {s}");

        public void Error(string s) => Console.WriteLine($"[ERROR] {s}");

        public void Exception(Exception e) => throw e;
    }

    public class TofuEcsContainer : UnmanagedEcsContainer
    {
        public List<Tofunaut.TofuECS.ISystem> Systems { get; }
        public Simulation Simulation { get; set; }
        public Dictionary<Type, Action> SimulationRegistrations { get; set; }

        public void RegisterComponentType<A>()
            where A : unmanaged
        {
            if (!SimulationRegistrations.ContainsKey(typeof(A)))
            {
                base.RegisterComponentType<A>();
                SimulationRegistrations.Add(typeof(A), () =>
                {
                    Simulation.RegisterComponent<A>(1);
                });
            }
        }

        public TofuEcsContainer()
        {
            this.Systems = new List<Tofunaut.TofuECS.ISystem>();
            this.SimulationRegistrations = new Dictionary<Type, Action>();
        }

        public override void Init()
        {
            this.Simulation = new Simulation(new TestLogService(), Systems.ToArray());
            foreach (var item in SimulationRegistrations)
            {
                item.Value.Invoke();
            }
            this.Simulation.Initialize();
            //base.Init();
        }

        public override void AddSystem<A>(UnmanagedUnifiedSystem<A> system)
        {
            this.RegisterComponentType<A>();
            var result = new TofuSystem<A>()
            {
                System = system
            };
            this.Systems.Add(result);
        }

        public override void AddSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
        {
            this.RegisterComponentType<A>();
            this.RegisterComponentType<B>();
            var result = new TofuSystem<A, B>()
            {
                System = system
            };
            this.Systems.Add(result);
        }

        public override void AddSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
        {
            this.RegisterComponentType<A>();
            this.RegisterComponentType<B>();
            this.RegisterComponentType<C>();
            var result = new TofuSystem<A, B, C>()
            {
                System = system
            };
            this.Systems.Add(result);
        }

        public override void AddSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
        {
            this.RegisterComponentType<A>();
            this.RegisterComponentType<B>();
            this.RegisterComponentType<C>();
            this.RegisterComponentType<D>();
            var result = new TofuSystem<A, B, C, D>()
            {
                System = system
            };
            this.Systems.Add(result);
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            var entity = this.Simulation.CreateEntity();
            var result = new TofuEntity(this.Simulation)
            {
                Id = entity
            };
            return result;
        }

        public override Core.ISystem GetSystem<A>(UnmanagedUnifiedSystem<A> system)
        {
            this.RegisterComponentType<A>();
            var result = new TofuSystem<A>()
            {
                System = system
            };
            return result;
        }

        public override Core.ISystem GetSystem<A, B>(UnmanagedUnifiedSystem<A, B> system)
        {
            var result = new TofuSystem<A, B>()
            {
                System = system
            };
            return result;
        }

        public override Core.ISystem GetSystem<A, B, C>(UnmanagedUnifiedSystem<A, B, C> system)
        {
            var result = new TofuSystem<A, B, C>()
            {
                System = system
            };
            return result;
        }

        public override Core.ISystem GetSystem<A, B, C, D>(UnmanagedUnifiedSystem<A, B, C, D> system)
        {
            var result = new TofuSystem<A, B, C, D>()
            {
                System = system
            };
            return result;
        }

        public override void Run()
        {
            Simulation.Tick();
        }
    }
}