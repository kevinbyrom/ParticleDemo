using System;
using Microsoft.Xna.Framework;


namespace ParticleDemo.Desktop
{
    public class Particle
    {
        const float Decel = 0.1f;
        const float Elasticity = 0.9f;

        public Vector2 Anchor;
        public Vector2 Forward;
        public float Velocity;
        public Vector2 Offset;
        public Vector2 Pos { get { return this.Anchor + this.Offset; } }

        public int SpriteIdx;

        public void Update(GameTime gameTime)
        {
            this.Offset += this.Forward * this.Velocity;

            this.Velocity -= Decel;
            if (this.Velocity < 0.0f)
                this.Velocity = 0.0f;

            this.Offset.X = this.Offset.X * Elasticity;
            this.Offset.Y = this.Offset.Y * Elasticity;
        }

        public void Wobble()
        {
            this.Forward = new Vector2(1, 0);
            this.Velocity = 1;
        }
    }
}
