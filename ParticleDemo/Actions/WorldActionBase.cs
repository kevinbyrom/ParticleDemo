using System;
using ParticleDemo.Desktop;


namespace ParticleDemo.Desktop.Actions
{
    public abstract class WorldActionBase
    {
        public World World { get; protected set; }

        public WorldActionBase(World world)
        {
            this.World = world;
        }

        public abstract void Execute();
    }
}
