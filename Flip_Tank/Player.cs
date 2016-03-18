using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    class Player
    {
        //attributes and properties
        public Rectangle position;  //where player is on the screen
        public Texture2D playerTexture;
        public Texture2D bulletTexture;
        public bool spawnBullet = false;
        public Rectangle bulletPosition = new Rectangle(0,0,10,10);

        int speed = 2; //Speed player can move left and right

        int groundHeight; //Height when player is sitting on ground
        const double gravAcceleration = 0.1; //Acceleration due to virtual gravity
        int fallSpeed; //Current falling speed to be increased by gravity
        int framesFalling; //Number of frames player has been falling

        enum state { up, down, jump, shoot };   //players current action
        enum height { ground, air};
        height hgt = height.ground; //player starts at ground level
        state move;

        public Rectangle Position
        {
            get { return position; }
            set { }
        }
        public Texture2D Texture
        {
            get { return playerTexture; }
            set { }
        }
        public bool SpawnBullet
        {
            get { return spawnBullet; }
            set { }
        }

        //parameterized constructors
        public Player(int x, int y, int width, int height)
        {
            position.X = x;
            position.Y = y;
            position.Width = width;
            position.Height = height;
            groundHeight = y;

            if(Game1.DEVMODE)
            {
                //Run method that reads text file to replace player values
            }

        }

        //methods
        public void Movement()  //Determines player movement state to be used in Game1 Update()
        {
            KeyboardState input = Keyboard.GetState();

            Fall(); //Make player fall if still in air
            
            if (hgt == height.ground)   //can't shoot unless jumping
            {
                spawnBullet = false;
            }
            if (input.IsKeyDown(Keys.A) == true)
            {
                position.X = position.X - speed;
            }
            if (input.IsKeyDown(Keys.D) == true)
            {
                position.X = position.X + speed;
            }
            if (input.IsKeyDown(Keys.Space) == true)    //will be changed to single key press
            {
                //Don't let the tank continue going up into the air
                if (hgt != height.air)
                {
                    position.Y = position.Y - 100;
                }

                hgt = height.air;
                //flipping method added here
                //if flip is completed without shooting, hgt = height.ground
            }
            
            
            //Pressing 'S' doesn't work with gravity will uncomment if game requires it
            /*if (input.IsKeyDown(Keys.S) == true && hgt == height.air)   //key may be changed to space
            {
                spawnBullet = true;
                position.Y = position.Y + 10; //will be removed after flip, for testing purposes only
                hgt = height.ground;
            }*/
            
        }

        public void Shoot() //sets bullet coordinates to above tank, will be changed when flipping
        {
            bulletPosition.X = position.X;
            bulletPosition.Y = bulletPosition.Y - 100;
        }

        //Brings tank back to the ground after a jump. Will most likely be heavily altered when flip is finished.
        private void Fall()
        {

            //If the distance between the player and the ground is less than the previous ground speed then just place player on ground.
            //Prevents clipping through ground
            if(position.Y + fallSpeed >= groundHeight)
            {
                position.Y = groundHeight;
                hgt = height.ground;
            }

            //If the player is in the air after a jump
            if(hgt == height.air)
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
    }
}