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
        public Texture2D texture;

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
            get { return texture; }
            set { }
        }

        //parameterized constructor
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
            
            if (input.IsKeyDown(Keys.W) == true && hgt == height.ground)
            {
                position.Y--;
            }
            if (input.IsKeyDown(Keys.S) == true && hgt == height.ground)
            {
                position.Y++;
            }
            if (input.IsKeyDown(Keys.Space) == true)
            {
                hgt = height.air;
                //flipping method added here
                //if flip is completed without shooting, hgt = height.ground

                if (input.IsKeyDown(Keys.Space) == true)
                {
                    //call shooting method
                    hgt = height.ground;
                }
            }
        }
    }
}