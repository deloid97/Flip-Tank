using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    class Bullet
    {
        Rectangle location;

        //Can change all general bullets' stats from here
        int bulletSpeed = 6;
        int damage = 25; 
        bool isActive; //Tells whether or not the bullet is currently active flying through the air
        int boundryY;

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

        //Property for bullet's active state
        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        //Property for bullet's speed
        public int BulletSpeed
        {
            get
            {
                return bulletSpeed;
            }

            set
            {
                bulletSpeed = value;
            }
        }

        //Property for Bullet's damage
        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
            }
        }

        //Property for the bullet's y boundry
        public int BoundryY
        {
            get
            {
                return boundryY;
            }

            set
            {
                boundryY = value;
            }
        }

        //Constructs a bullet with a location and a Y axis boundry that removes it when it goes over
        public Bullet(Rectangle locRec, int bndryY)
        {
            location = locRec;
            IsActive = true;
            boundryY = bndryY;
        }


        /// <summary>
        /// Moves bullet down the screen along the y-axis with a certain bullet speed (this is a basic version of a possible bullet move method) (should be called once a frame)
        /// ADDS to the Y location so NEGATIVE numbers move UP
        /// </summary>
        public void MoveY()
        {
            //While the bullet is active continue moving it
            location.Y = location.Y + BulletSpeed;
        }

        /// <summary>
        /// Checks collision of the bullet with the player of the game (or the borders of the game) and makes it inactive if it is colliding
        /// </summary>
        /// <param name="player"></param>
        public void CheckCollision(Player player)
        {
            
            if (location.Y > boundryY) //If the bullet hits the ground AT THE BOTTOM of the screen
            {
                isActive = false;
            }
            else if (location.Contains(player.Position))
            {
                isActive = false;
                player.TakeDamage(Damage); 
            }

        }

        //Draws the bullet using a passed in SpriteBatch and texture
        public void Draw(SpriteBatch spritebatch, Texture2D texture)
        {
            spritebatch.Draw(texture, location, Color.Red);
        }

    }
}
