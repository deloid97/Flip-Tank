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
        Texture2D texture;
        int speed;
        bool isActive;


        public Bullet()
        {
            speed = 0; //TBD
        }

        //Property for the bullet's texture
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

        //Property for the bullet's active state
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

        //Property for the bullet's speed
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

        //Some method to move the bullet? Or should that go somewhere else?
    }
}
