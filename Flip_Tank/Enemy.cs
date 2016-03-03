using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    //Perhaps this class could be abstract? I don't think we want anyone making a "generic enemy" object
    class Enemy
    {
        Rectangle locationRec; //Location of the enemy
        Texture2D texture; //Texture of enemy to draw
        bool isAlive; //Holds whether or not the enemy is alive
        int speed; //How fast the enemy moves

        //Add a texture for when the enemy is killed? An explosion?

        //Property for the enemy's location rectangle
        public Rectangle LocationRec
        {
            get
            {
                return locationRec;
            }

            set
            {
                locationRec = value;
            }
        }

        //Property for X position of enemy
        public int X
        {
            get
            {
                return locationRec.X;
            }

            set
            {
                locationRec = new Rectangle(locationRec.X + value, locationRec.Y, locationRec.Width, locationRec.Height);
            }
        }

        //Property for Y position of enemy
        public int Y
        {
            get
            {
                return locationRec.Y;
            }

            set
            {
                locationRec = new Rectangle(locationRec.X, locationRec.Y + value, locationRec.Width, locationRec.Height);
            }
        }

        //Property for the enemy's texture
        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
            }
        }

        //Property for the enemy's alive state
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }

            set
            {
                isAlive = value;
            }
        }

        //Property for the enemy's speed
        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        //Have enemies check Collisons here since we only care when they collide with the player or a bullet

        //Check if enemy is colliding with the player and return the result
        //This returns a bool because we want to change the player's health accordingly
        public bool CheckCollision(Player player)
        {
            return false; //Temporary
        }

        //Check if the enemy is colliding with a bullet
        public void CheckCollision(List<Bullet> bulletList)
        {
            isAlive = false;
        }
    }
}
