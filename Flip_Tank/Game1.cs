using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Player p1 = new Player(0,350,70,70); //creates player object

        enum GameState { Menu, InWave, EndWave, GameOver };
        GameState gameState;

        Texture2D ground;

       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Setting this value to true will enable developer mode in the game
        private const bool devMode = false;
        public static bool DEVMODE
        {
            get
            {
                return devMode;
            }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            //Starts the Developer Tool if game is in dev mode
            if (DEVMODE)
            {
                GameBalanceTool gameBalance = new GameBalanceTool();
                gameBalance.Show();
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
            
            p1.playerTexture = Content.Load<Texture2D>("Tank");   //gives player texture
            p1.bulletTexture = Content.Load<Texture2D>("Bullet"); //gives bullet texture

            ground = Content.Load<Texture2D>("ground"); //gives ground texture

            // TODO: use this.Content to load your game content here
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

            p1.Movement();
            if(p1.spawnBullet == true)
            {
                p1.Shoot();
            }

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
            spriteBatch.Begin();

            //if(gameState == GameState.InWave)
            spriteBatch.Draw(p1.playerTexture, p1.position, Color.White); //draws player
            spriteBatch.Draw(ground, new Rectangle(0, 403, 840, 90),Color.White); //Draws ground

            if(p1.spawnBullet == true)
            {
               spriteBatch.Draw(p1.bulletTexture, p1.bulletPosition, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
