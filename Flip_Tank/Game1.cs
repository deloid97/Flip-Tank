using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;
using System;

namespace Flip_Tank
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Static variables for the Game window
        public static int GAME_WIDTH;
        public static int GAME_HEIGHT;

        Player p1 = new Player(0, 360, 70, 70); //creates player object

        //Wave variables
        Wave currWave; // current wave object
        int enemyIndex; //Index of enemy Games is to spawn next
        int spawnCoolDown; //How many frames before the next enemy can be spawned
        int currCoolDown; //How many frames it has been since the last enemy was spawned

        enum GameState { Menu, Controls, InWave, Pause, EndWave, GameOver };
        GameState gameState;

        
        Texture2D menu;
        Texture2D controls;
        Texture2D pause;
        Texture2D gameOver;

        Texture2D ground;
        Texture2D bullet;

        Texture2D flyer;
        Texture2D groundEnemy;

        SpriteFont mainFont;

        static List<Bullet> bulletList = new List<Bullet>(); //WILL CHANGE WHEN ENEMIES ARE IMPLEMENTED
        static List<PlayerBullet> playerBulletList = new List<PlayerBullet>();
        static List<Enemy> enemyList = new List<Enemy>(); //WILL CHANGE WHEN ENEMIES ARE IMPLEMENTED

        //WILL BE USED IF GAME BEGINS TO HAVE TOO MANY BULLETS AND MANY ENEMIES
        Thread bulletThread;

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

        //Property for the global EnemyList
        internal static List<Enemy> EnemyList
        {
            get
            {
                return enemyList;
            }

            set
            {
                enemyList = value;
            }
        }

        internal Player P1
        {
            get
            {
                return p1;
            }

            set
            {
                p1 = value;
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

            //Initalize game state
            gameState = GameState.Menu;
            


            //Initalize public window variables
            GAME_HEIGHT = GraphicsDevice.Viewport.Height;
            GAME_WIDTH = GraphicsDevice.Viewport.Width;

            //Initalize KeyboardStates
            currState = Keyboard.GetState();
            prevState = Keyboard.GetState();


            //Initialize first wave
            currWave = new Wave();
            spawnCoolDown = 120;
            currCoolDown = spawnCoolDown; //Set current cool down to spawn cool down to start first wave
            enemyIndex = 0;

            //Test an enemy
            //enemyList.Add(new Flyer());
            //enemyList.Add(new Ground());

            //Starts the Developer Tool if game is in dev mode
            /*if (DEVMODE)
            {
                GameBalanceTool gameBalance = new GameBalanceTool();
                gameBalance.Show();
            }*/

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            P1.playerTexture = Content.Load<Texture2D>("Tank");   //gives player texture
            ground = Content.Load<Texture2D>("ground"); //gives ground texture
            P1.bulletTexture = Content.Load<Texture2D>("Bullet"); //gives bullet texture
            P1.healthSegment = Content.Load<Texture2D>("HealthSegment"); //Gives health texture

            mainFont = Content.Load<SpriteFont>("MainFont"); //loading the font

            bullet = Content.Load<Texture2D>("Bullet");

            flyer = Content.Load<Texture2D>("flyer");
            groundEnemy = Content.Load<Texture2D>("groundEnemy");

            menu = Content.Load<Texture2D>("MainMenu");
            pause = Content.Load<Texture2D>("pause");
            controls = Content.Load<Texture2D>("Controls");
            gameOver = Content.Load<Texture2D>("GameOver");

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
                    gameState = GameState.Controls;
                }

                prevState = currState; //Set previous state to last current state                
            }
            //If the game is at the controls
            else if (gameState == GameState.Controls)
            {
                if (currState.IsKeyUp(Keys.Enter) && prevState.IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.InWave;
                }
            }
            //If the game is playing
            else if (gameState == GameState.InWave)
            {
                if (P1.Health <= 0)
                {
                    gameState = GameState.GameOver;

                    //Clear out the bullets
                    BulletList.Clear();
                    PlayerBulletList.Clear();
                }

                //Check if the player paused the game
                if (currState.IsKeyUp(Keys.P) && prevState.IsKeyDown(Keys.P))
                {
                    gameState = GameState.Pause;
                }
                // activate developer tool
                if(currState.IsKeyUp(Keys.F1) && prevState.IsKeyDown(Keys.F1))
                {
                    GameBalanceTool gameBalance = new GameBalanceTool();
                    gameBalance.Show();
                }

                //Check for player movement
                P1.Movement();


                //Move and Manage enemies and bullets
                MoveBullets();
                MoveEnemies();

                BulletManage();
                EnemyManage();

                //Manage the wave
                WaveManage();
                

                /** Threading code to use if optimization needed
                bulletThread = new Thread(BulletManage);
                bulletThread.Start();
                */

                //keeps tank from moving past screen
                if (P1.position.X < 0)
                {
                    P1.position.X = 0;
                }
                if (P1.position.X > GAME_WIDTH - P1.position.Width)
                {
                    P1.position.X = GAME_WIDTH - P1.position.Width;
                }


            }
            else if (gameState == GameState.Pause)
            {
                //Check if player unpaused the game
                if (currState.IsKeyUp(Keys.P) && prevState.IsKeyDown(Keys.P))
                {
                    gameState = GameState.InWave;
                }
            }
            else if (gameState == GameState.GameOver)
            {
                if (currState.IsKeyUp(Keys.Enter) && prevState.IsKeyDown(Keys.Enter))
                {
                    //Reset player
                    P1.Reset();

                    //Clear all active items off screen
                    bulletList.Clear();
                    playerBulletList.Clear();
                    enemyList.Clear();

                    //Reset the wave
                    currWave = new Wave();
                    enemyIndex = 0;
                    currCoolDown = spawnCoolDown;

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
            if (gameState == GameState.Menu)
            {
                spriteBatch.Draw(menu, new Rectangle(0, 0, GAME_WIDTH, GAME_HEIGHT), Color.White);
            }
            else if (gameState == GameState.Controls)
            {
                spriteBatch.Draw(controls, new Rectangle(0, 0, GAME_WIDTH, GAME_HEIGHT), Color.White);
            }
            else if (gameState == GameState.InWave)
            {
                spriteBatch.Draw(P1.playerTexture, P1.position, null, Color.White, P1.SpinPos, P1.Origin, SpriteEffects.None, 0); //draws player
                spriteBatch.Draw(ground, new Rectangle(0, 403, 840, 90), Color.White); //Draws ground
                P1.DrawHealth(spriteBatch); //Draws the health
                spriteBatch.DrawString(mainFont, "Health", new Vector2(25, 420), Color.Black); //drawing font to overlap Health

                DrawEnemies();
                DrawBullets();

                //Draw what wave the player is on
                spriteBatch.DrawString(mainFont, "Current Wave: " + currWave.WaveNumber, new Vector2(10, 10), Color.White);



            }
            else if (gameState == GameState.Pause)
            {
                //Draw all the in-game stuff but it won't be updating
                spriteBatch.Draw(P1.playerTexture, P1.position, null, Color.White, P1.SpinPos, P1.Origin, SpriteEffects.None, 0); //draws player
                spriteBatch.Draw(ground, new Rectangle(0, 403, 840, 90), Color.White); //Draws ground
                P1.DrawHealth(spriteBatch); //Draws the health

                //Draw pause text
                spriteBatch.Draw(pause, new Rectangle(275, 200, 250, 80), Color.White);
            }
            else if (gameState == GameState.GameOver)
            {
                //Draw the GameOver screen
                spriteBatch.Draw(gameOver, new Rectangle(0, 0, GAME_WIDTH, GAME_HEIGHT), Color.White);

                //Draw restart text
                spriteBatch.DrawString(mainFont, "Press enter to restart...", new Vector2(0, 0), Color.White);

                //Draw what wave the player died on
                spriteBatch.DrawString(mainFont, "Waves Survived: " + (currWave.WaveNumber - 1), new Vector2(10, GAME_HEIGHT/2), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


        /// <summary>
        /// Manages all the bullets and their collisions on screen as well as remove them from their list if they are inActive
        /// Does NOT move the bullets since that needs to be frame dependent and this can be on a different thread
        /// </summary>
        private void BulletManage()
        {
            //Manage enemy bullets
            if (BulletList.Count > 0)
            {
                int count = BulletList.Count;
                for(int i = 0; i < count; i++)
                {
                    Bullet currB = BulletList[i];
                    currB.CheckCollision(P1);

                    //Take the bullet out of the list if the collision check caused it to be inactive
                    if (!currB.IsActive)
                    {
                        BulletList.Remove(currB);
                    }

                    count = BulletList.Count;
                }
               
            }

            //Manage player bullets
            if (PlayerBulletList.Count > 0)
            {
                int count = PlayerBulletList.Count;
                for (int i = 0; i < count; i++)
                {
                    PlayerBullet currPB = PlayerBulletList[i];
                    currPB.CheckCollision(EnemyList);

                    //Take the bullet out of the list if the collision check caused it to be inactive
                    if (!currPB.IsActive)
                    {
                        PlayerBulletList.Remove(currPB);
                    }

                    //Updates the for loop boundary since a bullet could be added before it finishes
                    count = PlayerBulletList.Count;
                }
            }
        }

        /// <summary>
        /// Removes Enemies from the Enemy List if they are inactive and calls Shoot on active Enemies
        /// </summary>
        private void EnemyManage()
        {
            int count = EnemyList.Count;

            for(int i = 0; i < count; i++)
            {
                Enemy currE = EnemyList[i];

                //Check if the player ran into this enemy
                currE.PlayerContact(p1);

                if(!currE.IsActive)
                {
                    EnemyList.Remove(currE);
                }
                else
                {
                    currE.Shoot();
                }

                count = EnemyList.Count;
            }
        }


        /// <summary>
        /// Manages the wave the player is on
        /// </summary>
        private void WaveManage()
        {
            //If the wave is over make a new wave and reset other wave variables
            if(enemyIndex >= currWave.EnemyList.Count && enemyList.Count == 0)
            {
                currWave.NewWave();
                currCoolDown = 0;
                enemyIndex = 0;
            }
            //Wave isn't over but it's time to spawn an enemy
            //i.e The cool down is over AND there are less enemies on screen than the max AND there is still some enemy in the wave list to spawn
            else if(currCoolDown >= spawnCoolDown && enemyList.Count < currWave.MaxEnemiesOnScreen && enemyIndex < currWave.EnemyList.Count)
            {
                //Add enemy from wave's list (according to enemy index) to the game's list to spawn it
                enemyList.Add(currWave.EnemyList[enemyIndex]);
                enemyIndex++;
                currCoolDown = 0;
            }
            //Wave is still going but it is not time to spawn
            else
            {
                currCoolDown++;
            }
        }

        /// <summary>
        /// Called to increment all the bullets each frame
        /// </summary>
        private void MoveBullets()
        {
            if (BulletList.Count > 0)
            {
                foreach (Bullet currB in BulletList)
                {
                    currB.Move();
                }
            }

            if (PlayerBulletList.Count > 0)
            {
                foreach (PlayerBullet currPB in PlayerBulletList)
                {
                    currPB.Move();
                }
            }

        }

        /// <summary>
        /// Moves all the enemies in the enemy list
        /// </summary>
        private void MoveEnemies()
        {
            if(enemyList.Count > 0)
            {
               foreach(Enemy e in EnemyList)
               {
                    e.Move();
               }     
            }
        }

        /// <summary>
        /// Called to draw all the bullets each frame
        /// </summary>
        private void DrawBullets()
        {
            if (BulletList.Count > 0)
            {
                foreach (Bullet currB in BulletList)
                {
                    currB.Draw(spriteBatch, bullet);
                }
            }

            if (PlayerBulletList.Count > 0)
            {
                foreach (PlayerBullet currPB in playerBulletList)
                {
                    currPB.Draw(spriteBatch, bullet);
                }
            }
        }

        /// <summary>
        /// Draws all the enemies in the enemy list
        /// </summary>
        private void DrawEnemies()
        {
            if(EnemyList.Count > 0)
            {
                foreach (Enemy e in EnemyList)
                {
                    if(e is Flyer)
                    {
                        e.Draw(spriteBatch, flyer);
                    }
                    else if(e is Ground)
                    {
                        e.Draw(spriteBatch, groundEnemy);
                    }
                }
            }

        }
    }
}
