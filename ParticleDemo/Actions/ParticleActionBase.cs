using System;


namespace ParticleDemo.Desktop.Actions
{
    public abstract class ParticleActionBase : IGameAction
    {
        public Particle Particle { get; protected set; }


        public ParticleActionBase(Particle particle)
        {
            this.Particle = particle;
        }

        public abstract void Execute();
    }
}
