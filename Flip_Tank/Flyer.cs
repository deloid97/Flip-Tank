using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    class Flyer : Enemy
    {

        int reloadTime; //Time to pause between shots at the player

        public Flyer() : base()
        {

        }

        //Create a bullet and fire it at the player
        public void Fire(Rectangle playerRec)
        {

        }

        //Moves the flyer enemy
        public void Move()
        {

        }


        /*
        //Perhaps use a move method comparing the player's x value to the enemy's to see which way to go?
        public void Move(int playerX)
        {

        }
        */
    }
}
