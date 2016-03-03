using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    class Player
    {
        Rectangle locationRec; //Location of the player
        Texture2D texture; //Texture of the player
        int health; //The player's current health
        int roatationSpeed; //Speed of the flip
        int speed; //General player speed
        int bulletSpeed; //How fast the player's bullets move
        int jumpHeight; //How high the player jumps
        int maxBullets; //How many bullets the player can have on screen at once
        int waveScore; //The score on the current wave
        int totalScore; //The score for the entire game

        

        //Somehow does the flip
        public void Flip()
        {

        }

        //Fire a bullet
        public void Fire()
        {

        }

        //Checks to see if the player hit an enemy bullet
        public void CheckCollision(List<Bullet> bulletList)
        {
            foreach(Bullet bullet in bulletList)
            {
                //Don't care if player hits own bullet somehow
                if(bullet is PlayerBullet)
                {
                    return;
                }
            }
        }

        //Property for the current wave's score
        public int WaveScore
        {
            get
            {
                return waveScore;
            }

            set
            {
                waveScore = value;
            }
        }

        //Property for the total game score
        public int TotalScore
        {
            get
            {
                return totalScore;
            }

            set
            {
                totalScore = value;
            }
        }

        //Property for the player's texture
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

        //Property for the player's health
        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        //Property for the player's location rectangle
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

        //Property for X position of player
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

        //Property for Y position of player
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
    }
}
