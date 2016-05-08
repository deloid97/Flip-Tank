using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flip_Tank
{
    /// <summary>
    /// Enemy
    /// A class to describe any basic enemy. Is extended to be able to build specific types of enemies.
    /// </summary>
    class Enemy
    {
        //Determines whether the plane is going left to right or if it is flipped
       public enum orientation { normal, flipped};
       public orientation orient;

        bool isActive; //Tells whether or not the enemy is alive and active 

        Rectangle position;
        Rectangle bulletPosition;
        int speed; //The enemy's movement speed
        int bulletSpeed; //The speed of the enemy's bullets
        int shotCoolDown; //How many frames must go by before another shot can be fired
        int currCoolDown; //How long the enemy has been currently waiting for the next shot


        public Rectangle Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

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

        public int ShotCoolDown
        {
            get
            {
                return shotCoolDown;
            }

            set
            {
                shotCoolDown = value;
            }
        }

        public Rectangle BulletPosition
        {
            get
            {
                return bulletPosition;
            }

            set
            {
                bulletPosition = value;
            }
        }

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

        //Moves the enemy (DOES NOT MOVE THE BULLET POSITION! THIS MUST BE DONE IN A "NEW" MOVE METHOD FOR EACH ENEMY SINCE THEY SHOOT FROM DIFFERENT POSITIONS)
        public void Move()
        {
            //Move to the right if the orientation is normal
            if(orient == orientation.normal)
            {
                position.X = position.X + speed;

                //Check if the right boundry has been reached
                if(Position.X >= Game1.GAME_WIDTH)
                {
                    orient = orientation.flipped;
                }

            }
            else
            {
                position.X = position.X + speed;

                //Check if the left boundry has been reached (with the entire texture about to leave the screen)
                if(Position.X <= 0 - Position.Width)
                {
                    orient = orientation.normal;
                }
            }
        }

        //Fires a bullet if the cool down has transpired (SHOULD BE CALLED ONCE A FRAME)
        public void Shoot()
        {
            //Fire if the cool down has been passed
            if(currCoolDown >= shotCoolDown)
            {
                Bullet b = new Bullet(bulletPosition, 400, BulletSpeed);
                Game1.BulletList.Add(b);

                //Reset cool down
                currCoolDown = 0;
            }
            else
            {
                //Increment cool down if the enemy is still cooling down
                currCoolDown++;
            }
        }

        //Draws the enemy
        public void Draw(SpriteBatch spritebatch, Texture2D texture)
        {
            //Draw the image flipped if the orientation is flipped
            if (orient == orientation.normal)
            {
                spritebatch.Draw(texture, position, Color.White);
            }
            else
            {
                spritebatch.Draw(texture, position, position, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            }
        } 
    }
}
