using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    class Bullet
    {
        Texture2D txture;
        Rectangle location;

        //Property for Texture
        public Texture2D Texture
        {
            get
            {
                return txture;
            }

            set
            {
                txture = value;
            }
        }

        //Property for Location Rectangle
        public Rectangle Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        //Constructs a bullet with a location
        public Bullet(Rectangle locRec)
        {
            location = locRec;
        }


        /// <summary>
        /// Moves bullet along the y-axis (this is a basic version of a possible bullet move method)
        /// ADDS to the Y location so NEGATIVE numbers move UP
        /// </summary>
        /// <param name="amount"></param>
        public void MoveY(int amount)
        {
            location.Y = location.Y + amount;
        }

        //Draws the bullet using a passed in SpriteBatch
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(txture, location, Color.Red);
        }

    }
}
