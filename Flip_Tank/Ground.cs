using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flip_Tank
{
    /// <summary>
    /// A ground enemy does not shoot, but hurts the player on contact damage
    /// </summary>
    class Ground : Enemy
    {

        int scaleFactor; //Scales the size of the Ground Enemy down by this amount

        public Ground() : base()
        {
            //Set up starting values for a ground enemy
            Speed = 3;

            //Start flipped since it spawns from the right side of the screen
            orient = orientation.flipped;

            scaleFactor = 10;
            Position = new Rectangle(Game1.GAME_WIDTH, 403 - 397/scaleFactor, 960/scaleFactor, 397/scaleFactor);

            IsActive = true;

        }


        public override void Shoot()
        {
            //Do nothing
        }
    }
}
