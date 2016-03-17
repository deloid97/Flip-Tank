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
        }

        //methods
        public void Movement()  //Determines player movement state to be used in Game1 Update()
        {
            KeyboardState input = Keyboard.GetState();
            
            if (hgt == height.ground)   //can't shoot unless jumping
            {
                spawnBullet = false;
            }
            if (input.IsKeyDown(Keys.A) == true && hgt == height.ground)
            {
                position.X--;
            }
            if (input.IsKeyDown(Keys.D) == true && hgt == height.ground)
            {
                position.X++;
            }
            if (input.IsKeyDown(Keys.Space) == true)    //will be changed to single key press
            {
                position.Y = position.Y - 10;   //will be changed to gradual movement later
                hgt = height.air;
                //wait a second then position.Y + 10
                //flipping method added here
                //if flip is completed without shooting, hgt = height.ground
            }
            if (input.IsKeyDown(Keys.S) == true && hgt == height.air)   //key may be changed to space
            {
                spawnBullet = true;
                position.Y = position.Y + 10; //will be removed after flip, for testing purposes only
                hgt = height.ground;
            }
            
        }

        public void Shoot() //sets bullet coordinates to above tank, will be changed when flipping
        {
            bulletPosition.X = position.X;
            bulletPosition.Y = bulletPosition.Y - 100;
        }
    }
}