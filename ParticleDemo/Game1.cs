using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParticleDemo.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const int ScreenWidth = 1920;
        const int ScreenHeight = 1080;
        const int NumParticlesX = 40;
        const int NumParticlesY = 40;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Particle[] particles;
        Texture2D spriteTexture;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();


            // Initialize the particles

            this.particles = new Particle[NumParticlesX * NumParticlesY];

            for (int y = 0; y < NumParticlesY; y++)
            {
                for (int x = 0; x < NumParticlesX; x++)
                {
                    int idx = x + (y * NumParticlesY);

                    this.particles[idx] = new Particle();
                    this.particles[idx].Pos = new Vector2((ScreenWidth / NumParticlesX) * x, (ScreenWidth / NumParticlesY) * y);
                    this.particles[idx].SpriteIdx = 0;
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.spriteTexture = Content.Load<Texture2D>("Sprites");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            this.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
   
            for (int y = 0; y < NumParticlesY; y++)
            {
                for (int x = 0; x < NumParticlesX; x++)
                {
                    int idx = x + (y * NumParticlesY);

                    this.spriteBatch.Draw(this.spriteTexture, this.particles[idx].Pos, new Rectangle(0, 0, 16, 16), Color.White, 0f, new Vector2(8, 8), 1.0f, SpriteEffects.None, 1.0f);
                }
            }

            this.spriteBatch.End();
        }
    }
}
