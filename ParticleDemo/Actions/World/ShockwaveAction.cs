using System;
namespace ParticleDemo.Desktop.Actions
{
    public class ShockwaveAction : WorldActionBase
    {
        const int Strength = 10;

        public ShockwaveAction(World world) : base(world)
        {
        }

        public override void Execute()
        {
            var center = this.World.Center;

            foreach (var particle in this.World.Particles)
            {
                var offset = particle.Pos - center;
                offset.Normalize();
                particle.ApplyForce(offset * Strength);
            }
        }
    }

    public static class ShockwaveExtension
    {
        public static void Shockwave(this World world)
        {
            var action = new ShockwaveAction(world);
            action.Execute();
        }
    }
}
