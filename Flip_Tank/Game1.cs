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
        Texture2D menu;

        KeyboardState currState, prevState; //Holds the keyboard states

       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Setting this value to true will enable developer mode in the game
        private const bool devMode = true;
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

            //Initalize KeyboardStates
            currState = Keyboard.GetState();
            prevState = Keyboard.GetState();

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
            p1.healthSegment = Content.Load<Texture2D>("HealthSegment"); //Gives health texture

            menu = Content.Load<Texture2D>("MainMenu");
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

            //If the game is at the menu, only check if the player pressed enter.
            if (gameState == GameState.Menu)
            {
                currState = Keyboard.GetState();

                if (currState.IsKeyUp(Keys.Enter) && prevState.IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.InWave;
                }

                prevState = currState; //Set previous state to last current state                
            }
            else if (gameState == GameState.InWave)
            {
                p1.Movement();
<<<<<<< HEAD

                //TANK DOES NOT FIRE YET
=======
                //keeps tank from moving past screen
                if (p1.position.X < 0)
                {
                    p1.position.X = 0;
                }
                if (p1.position.X > GraphicsDevice.Viewport.Width - p1.position.Width)
                {
                    p1.position.X = GraphicsDevice.Viewport.Width - p1.position.Width;
                }
>>>>>>> 32413ead342f8775ea09aa5b719f4d4787b292de
                if (p1.spawnBullet == true)
                {
                    p1.Shoot();
                }
<<<<<<< HEAD

                //keeps tank from moving past screen
                if (p1.position.X < 0)
                {
                    p1.position.X = 0;
                }
                if (p1.position.X > GraphicsDevice.Viewport.Width - p1.position.Width)
                {
                    p1.position.X = GraphicsDevice.Viewport.Width - p1.position.Width;
                }
              
            }

=======
>>>>>>> 32413ead342f8775ea09aa5b719f4d4787b292de

                base.Update(gameTime);
            }
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

            //Draw main menu
            if(gameState == GameState.Menu)
            {
                spriteBatch.Draw(menu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            else if(gameState == GameState.InWave)
            {
                spriteBatch.Draw(p1.playerTexture, p1.position, Color.White); //draws player
                spriteBatch.Draw(ground, new Rectangle(0, 403, 840, 90), Color.White); //Draws ground
                p1.DrawHealth(spriteBatch); //Draws the health

                if (p1.spawnBullet == true)
                {
                    spriteBatch.Draw(p1.bulletTexture, p1.bulletPosition, Color.White);
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
