using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    class PlayerBullet : Bullet
    {
        float spinPos;
        //Constructs a Player Bullet (CHANGE PLAYER BULLET SPEED FROM HERE)
        public PlayerBullet(Rectangle locRec, int bndryY, float spin):base(locRec,bndryY, 6)
        {
            spinPos = spin;
        }

        /// <summary>
        /// Moves bullet according to the player's current spin position when the bullet was created (should be called once a frame)
        /// ADDS to the Y location so NEGATIVE numbers move UP
        /// </summary>
        public new void Move()
        {
            //If the tank is just sitting on the ground with no spin Position just shoot straight up
            if(spinPos == 0)
            {
                Location = new Rectangle(Location.X, Location.Y - BulletSpeed, Location.Width, Location.Height);
                return;
            }
            //Location = new Rectangle(Location.X + ((int)(spinPos) + BulletSpeed), Location.Y + ((int)(spinPos) + BulletSpeed), Location.Width, Location.Height)

            double angle = spinPos / (2 * Math.PI);

            if (angle > 0 && angle < .25)
                Location = new Rectangle(Location.X + ((int)(Math.Cos(spinPos)) + BulletSpeed), Location.Y - ((int)(Math.Sin(spinPos)) + BulletSpeed), Location.Width, Location.Height);
            else if (angle >= .25 && angle < .50)
                Location = new Rectangle(Location.X + ((int)(Math.Cos(spinPos)) + BulletSpeed), Location.Y + ((int)(Math.Sin(spinPos)) + BulletSpeed), Location.Width, Location.Height);
            else if (angle >= .50 && angle < .75)
                Location = new Rectangle(Location.X - ((int)(Math.Cos(spinPos)) + BulletSpeed), Location.Y + ((int)(Math.Sin(spinPos)) + BulletSpeed), Location.Width, Location.Height);
            else if (angle >= .75 && angle < 1.00)
                Location = new Rectangle(Location.X - ((int)(Math.Cos(spinPos)) + BulletSpeed), Location.Y - ((int)(Math.Sin(spinPos)) + BulletSpeed), Location.Width, Location.Height);

        }

        /// <summary>
        /// Checks collision of the bullet with any enemy in the game (or if its over the borders of the game) and makes it inactive if it is colliding
        /// </summary>
        /// <param name="player"></param>
        public void CheckCollision(List<Enemy> enemies)
        {
            //If the bullet goes off the top or bottom of the screen of the screen
            //400 is the current value used for the ground
            if (Location.Y < BoundryY || Location.Y > 400) 
            {
                IsActive = false;
            }
            else if(enemies.Count > 0)
            {
                foreach(Enemy currE in enemies)
                {
                    if (Location.Intersects(currE.Position))
                    {
                        IsActive = false;

                        //Destroy enemy
                        currE.IsActive = false;
                    }
                }
            }
            

        }

        //Overrides the bullet draw to draw a white bullet
        public new void Draw(SpriteBatch spritebatch, Texture2D texture)
        {
            spritebatch.Draw(texture, Location, Color.White);
        }

    }
}
