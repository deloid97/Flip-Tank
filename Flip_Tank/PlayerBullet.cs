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
        //Constructs a Player Bullet
        public PlayerBullet(Rectangle locRec, int bndryY, float spin):base(locRec,bndryY)
        {
            spinPos = spin;
        }

        /// <summary>
        /// Moves bullet according to the player's current spin position when the bullet was created (should be called once a frame)
        /// ADDS to the Y location so NEGATIVE numbers move UP
        /// CURRENTLY BUGGED
        /// </summary>
        public new void Move()
        {
            Location = new Rectangle(Location.X + ((int)(spinPos) + BulletSpeed), Location.Y + ((int)(spinPos) + BulletSpeed), Location.Width, Location.Height);
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
                    if (Location.Contains(currE.Position))
                    {
                        IsActive = false;
                        //Something about destroying enemy when implemented
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
