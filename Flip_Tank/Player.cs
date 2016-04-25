using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Flip_Tank
{
    class Player
    {
        //attributes and properties
        public Rectangle position;  //where player is on the screen
        public Rectangle defaultPosition; //Default player location
        public Texture2D playerTexture;
        public Texture2D bulletTexture;
        public Texture2D healthSegment; //A segment of the player's health

        //Shooting
        public Rectangle bulletPosition;

        //Jumping
        int maxJumpSpeed; //Max jump speed
        int currJumpSpeed; //Current jump speed
        int jumpHeight; //Height player jumps (FROM REFERENCE OF ORIGIN NOT THE GROUND: Saying "jumpHeight = 0" is making the tank jump to the origin)

        //Stats
        int speed; //Speed player can move left and right
        int maxHealth; //The player's max health
        int health; //The player's current health

        //Health Drawing
        const int HEALTH_START_X = 25; //Offset for first health segment
        Rectangle healthRec = new Rectangle(HEALTH_START_X, 420, 25, 30); //Starting location of the first health segment

        //Falling
        int groundHeight; //Height when player is sitting on ground
        const double gravAcceleration = 0.1; //Acceleration due to virtual gravity
        int fallSpeed; //Current falling speed to be increased by gravity
        int framesFalling; //Number of frames player has been falling

        //Spinning
        Vector2 tankOrigin;
        float spinPos;
        bool spinOnce;

        //Movement States
        enum state {sit, jump, fall};   //players current action
        enum height { ground, air };
        height hgt = height.ground; //player starts at ground level
        state move;

        //Input states
        KeyboardState currKState;
        KeyboardState prevKState;
        MouseState currMState;
        MouseState prevMstate;

        public Rectangle Position
        {
            get { return position; }
            set { }
        }

        public float SpinPos
        {
            get { return spinPos; }
        }
        public Texture2D Texture
        {
            get { return playerTexture; }
            set { }
        }

        public Texture2D HealthSegment
        {
            get
            {
                return healthSegment;
            }

            set { }
        }

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int GroundHeight
        {
            get
            {
                return groundHeight;
            }

            set
            {
                groundHeight = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return tankOrigin;
            }
        }

        //parameterized constructors
        public Player(int x, int y, int width, int height)
        {
            defaultPosition = new Rectangle(x, y, width, height);
            position = defaultPosition;
            bulletPosition = new Rectangle(x + width / 2, y + height + 20, 20, 20); //Set bullet position width and height relative of the texture image
            GroundHeight = y;
            tankOrigin = new Vector2(width, height); // set spin axis to center of the tank

            //Current default values
            speed = 2;
            jumpHeight = 100;
            maxJumpSpeed = 6;
            maxHealth = 100;

            health = maxHealth; //Set health to whatever the max is to start

            //Initialize input states
            currKState = Keyboard.GetState();
            prevKState = Keyboard.GetState();
            currMState = Mouse.GetState();
            prevMstate = Mouse.GetState();

            if (Game1.DEVMODE)
            {
                //Run method that reads text file to replace player values
                ReadFile();
            }



        }

        //methods

        /// <summary>
        /// Handles all player input during the game
        /// </summary>
        public void Movement()
        {
            currKState = Keyboard.GetState();
            currMState = Mouse.GetState();

            

            if (move == state.jump)
            {
                Jump();
            }
            else if (move == state.fall) //If player is off ground and done jumping start falling
            {
                Fall();
            }

            if (currKState.IsKeyDown(Keys.A))
            {
                position.X = position.X - speed;
            }
            if (currKState.IsKeyDown(Keys.D))
            {
                position.X = position.X + speed;
            }
            if (currKState.IsKeyDown(Keys.Space))
            {
                if (hgt != height.air)
                {
                    move = state.jump;
                    hgt = height.air;
                    spinOnce = false;
                    spinPos = 0;
                }
            }
            if(hgt == height.air && !spinOnce)
            {
                spinPos += ((float)((/*speed of spin goes here*/1) * 2 * Math.PI)) / 100f;
                if(spinPos > (2*Math.PI))
                {
                    spinOnce = true;
                }
            }

            //Update bullet position
            bulletPosition.X = position.X;
            bulletPosition.Y = position.Y;

            //Check if player shot
            if(currMState.LeftButton == ButtonState.Released && prevMstate.LeftButton == ButtonState.Pressed)
            {
                Shoot();
            }
            

            //Update input states
            prevKState = currKState;
            prevMstate = currMState;
        }

        public void Shoot() //sets bullet coordinates to above tank, will be changed when flipping
        {
            //Only shoot if there are less than 3 player bullets already in existence
            if(Game1.PlayerBulletList.Count < 3)
            {
                PlayerBullet b = new PlayerBullet(bulletPosition, 0, SpinPos);
                Game1.PlayerBulletList.Add(b); //Add the bullet to the global list
            }

        }

        //Deals damage to the player by a set amount
        public void TakeDamage(int damage)
        {
            health = health - damage;
        }

        //Resets the player to starting values (more statements will be added with more features)
        public void Reset()
        {
            health = maxHealth;
            position = defaultPosition;
        }

        //PRIVATE METHODS

        //Brings tank back to the ground after a jump. Will most likely be heavily altered when flip is finished.
        private void Fall()
        {

            //If the distance between the player and the ground is less than the previous ground speed then just place player on ground.
            //Prevents clipping through ground
            if (position.Y + fallSpeed >= GroundHeight)
            {
                position.Y = GroundHeight;
                hgt = height.ground;
                move = state.sit;
            }

            //If the player is in the air after a jump
            if (hgt == height.air)
            {
                framesFalling++; //This test is run every frame so if it comes into here another frame has passed
                fallSpeed = (int)(Math.Ceiling(gravAcceleration * framesFalling)); //Calculate current speed based on acceleration factor and time passed
                position.Y = position.Y + (fallSpeed);
            }
            else //Reset falling speed and falling frames if player is on the ground
            {
                fallSpeed = 0;
                framesFalling = 0;
            }
        }

        //Logic for moving the player up for a frame of the jump 
        private void Jump()
        {
            //If the tank is over the jump height just put it at the jump height
            if(position.Y <= jumpHeight)
            {
                position.Y = jumpHeight;
                move = state.fall;
                return;
            }

            if (position.Y <= (jumpHeight/2) + jumpHeight) //If the player is approaching the jump height slow down
            {
                currJumpSpeed = (int)(maxJumpSpeed / 2); 
            }
            else
            {
                currJumpSpeed = maxJumpSpeed;
            }

            position.Y = position.Y - currJumpSpeed;
        }


        //Draws the player health on the screen (code from Tom's health class)
        //Currently looks awful, going to have to change it
        public void DrawHealth(SpriteBatch spriteBatch)
        {
            //Don't draw if health is below or equal to zero
            if(health <= 0)
            {
                return;
            }

            int segmentValue = maxHealth / 5; //5 segments of health. This may be changed.

            //Avoids a divide by zero error. If there are zero health segments just return
            if (segmentValue == 0)
            {
                return;
            }

            int numSegments = health / segmentValue; //Number of segments to be drawn



            //Draw bars until the current health is reached by incrementing i by the segment amount
            for (int i = 0; i < numSegments; i++)
            {
                spriteBatch.Draw(healthSegment, new Rectangle((healthRec.X * i) + HEALTH_START_X, healthRec.Y, healthRec.Width, healthRec.Height), Color.White);
            }
        }
    


    //Reads file generated by Development tool to change player values 
    //May be updated to be more efficient
    private void ReadFile()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader("ToolValues.txt");
            bool onSection = false; //Tells whether or not file is on the player section yet
            int sectionLine = 0; //Line within the correct section

            while (true) //NOT AN INFINITE LOOP. Made so that the current line is reliable and no lines are skipped by calling ReadLine multiple times
            {
                string currString = sr.ReadLine();
                if(currString != null)
                {
                      if (onSection)
                      {
                          sectionLine++;
                       
                          switch (sectionLine)
                          {
                              case 1:
                                  maxHealth = int.Parse(currString);
                                  break;
                              case 2:
                                  speed = int.Parse(currString);
                                  break;
                              case 3:
                                  jumpHeight = int.Parse(currString);
                                  break;
                           }
                      }

                      if (currString == "Player Values")
                      {
                          onSection = true;
                      }
               }
              else
              {
                  break;
              }
          }
               sr.Close();
        }
        catch (FileNotFoundException fnfe)
        {
            return; //If there's a file not found exception the tool is running for the first time and therefore no values will be changed
        }
        catch (IOException ioe)
        {
            Console.WriteLine("IO error: " + ioe.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured while reading file:" + e.Message);
        }

    }

    }
}