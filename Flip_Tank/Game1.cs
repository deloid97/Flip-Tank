using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Flip_Tank
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Player p1 = new Player(0,350,70,70); //creates player object

        enum GameState { Menu, InWave, Pause, EndWave, GameOver };
        GameState gameState;

        Texture2D ground;
        Texture2D menu;
        Texture2D pause;

        SpriteFont mainFont;

        static List<Bullet> bulletList = new List<Bullet>();
        static List<PlayerBullet> playerBulletList = new List<PlayerBullet>();

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

        //Property for the global BulletList
        internal static List<Bullet> BulletList
        {
            get
            {
                return bulletList;
            }

            set
            {
                bulletList = value;
            }
        }
        
        //Property for the global PlayerBulletList
        internal static List<PlayerBullet> PlayerBulletList
        {
            get
            {
                return playerBulletList;
            }

            set
            {
                playerBulletList = value;
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

            mainFont = Content.Load<SpriteFont>("mainFont"); //loading the font



            menu = Content.Load<Texture2D>("MainMenu");
            pause = Content.Load<Texture2D>("pause");
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

            currState = Keyboard.GetState(); //Update keyboard state


            //If the game is at the menu, only check if the player pressed enter.
            if (gameState == GameState.Menu)
            {
                
                if (currState.IsKeyUp(Keys.Enter) && prevState.IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.InWave;
                }

                prevState = currState; //Set previous state to last current state                
            }
            else if (gameState == GameState.InWave)
            {
                if(p1.Health <= 0)
                {
                    gameState = GameState.GameOver;
                }

                //TEMPORARY: Test out GameOver. Kills player
                if (currState.IsKeyUp(Keys.K) && prevState.IsKeyDown(Keys.K))
                {
                    p1.TakeDamage(100);
                }

                //Check if the player paused the game
                if (currState.IsKeyUp(Keys.P) && prevState.IsKeyDown(Keys.P))
                {
                    gameState = GameState.Pause;
                }

                p1.Movement();

                //TANK DOES NOT FIRE YET

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
            else if(gameState == GameState.Pause)
            {
                //Check if player unpaused the game
                if (currState.IsKeyUp(Keys.P) && prevState.IsKeyDown(Keys.P))
                {
                    gameState = GameState.InWave;
                }
            }
            else if(gameState == GameState.GameOver)
            {
                if(currState.IsKeyUp(Keys.Enter) && prevState.IsKeyDown(Keys.Enter))
                {
                    //Reset player values
                    //ADD MORE RESETS WHEN MORE IS IMPLEMENTED
                    p1 = new Player(0, 350, 70, 70);
                    gameState = GameState.InWave; //Go back to a new game
                }
            }

            prevState = currState; //Update prev keyboard state

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
                spriteBatch.DrawString(mainFont, "Health", new Vector2(25, 420), Color.Black); //drawing font to overlap Health

                if (p1.spawnBullet == true)
                {
                    spriteBatch.Draw(p1.bulletTexture, p1.bulletPosition, Color.White);
                }
            }
            else if(gameState == GameState.Pause)
            {
                //Draw all the in-game stuff but it won't be updating
                spriteBatch.Draw(p1.playerTexture, p1.position, Color.White); //draws player
                spriteBatch.Draw(ground, new Rectangle(0, 403, 840, 90), Color.White); //Draws ground
                p1.DrawHealth(spriteBatch); //Draws the health

                //Draw pause text
                spriteBatch.Draw(pause, new Rectangle(275, 200, 250, 80), Color.White);
            }
            else if(gameState == GameState.GameOver)
            {
                //Replace when asset put in for game over
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
