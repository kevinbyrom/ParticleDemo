using System;
using Microsoft.Xna.Framework;


namespace ParticleDemo.Desktop
{
    public class World
    {
        public Vector2 Size { get; set; }

        public Vector2 Center 
        { get 
            {
                return this.Size / 2;
            }
        }


        public Particle[] Particles;


        public void Initialize(int width, int height, int numParticlesX, int numParticlesY)
        {
            this.Size = new Vector2(width, height);
            this.Particles = new Particle[numParticlesX * numParticlesY];

            for (int y = 0; y < numParticlesY; y++)
            {
                for (int x = 0; x < numParticlesX; x++)
                {
                    int idx = x + (y * numParticlesX);

                    this.Particles[idx] = new Particle();
                    this.Particles[idx].AnchorAt(new Vector2((this.Size.X / numParticlesX) * x, (this.Size.Y / numParticlesY) * y));
                    this.Particles[idx].SpriteIdx = 0;
                }
            }
        }
    }
}
