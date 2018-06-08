using System;


namespace ParticleDemo.Desktop.Commands
{
    public interface IParticleCommand
    {
        Particle Particle { get; set; }
        void Execute();
    }
}
