using System;
using Microsoft.Xna.Framework;


namespace ParticleDemo.Desktop
{
    public class Particle
    {
        const float Damper = 0.9f;
        const float Elasticity = 2f;

        public Vector2 Anchor;
        public Vector2 Velocity = Vector2.Zero;
        public Vector2 Pos;

        public int SpriteIdx;

        public void Update(GameTime gameTime)
        {

            // Determine spring elasticity

            var offset = (this.Pos - this.Anchor);

            var force = -(offset) * Elasticity;

            this.Velocity += force;
            this.Velocity *= Damper;

            this.Pos += this.Velocity;
        }

        public void AnchorAt(Vector2 pos)
        {
            this.Anchor = pos;
            this.Pos = pos;
        }

        public void Wobble()
        {
            this.Velocity = new Vector2(5, 0);
        }

        public void ApplyForce(Vector2 force)
        {
            this.Velocity += force;
        }
    }
}
